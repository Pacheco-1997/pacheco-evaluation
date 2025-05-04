using System;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.Events;
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.ORM.Events;
using Ambev.DeveloperEvaluation.Unit.Application.Sales.TestData;
using AutoMapper;
using FluentAssertions;
using NSubstitute;
using Xunit;
using static System.Net.Mime.MediaTypeNames;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales
{
    public class UpdateSaleHandlerTests
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IUserRepository _userRepository;
        private readonly IBranchRepository _branchRepository;
        private readonly IProductRepository _productRepository;
        private readonly IEventRepositoryFactory _eventRepositoryFactory;
        private readonly IEventPublisherFactory _eventPublisherFactory;
        private readonly IMapper _mapper;
        private readonly UpdateSaleHandler _handler;

        public UpdateSaleHandlerTests()
        {
            _saleRepository = Substitute.For<ISaleRepository>();
            _userRepository = Substitute.For<IUserRepository>();
            _branchRepository = Substitute.For<IBranchRepository>();
            _productRepository = Substitute.For<IProductRepository>();
            _eventRepositoryFactory = Substitute.For<IEventRepositoryFactory>();
            _eventPublisherFactory = Substitute.For<IEventPublisherFactory>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SaleItem, UpdateSaleItemResult>();
                cfg.CreateMap<Sale, UpdateSaleResult>();
            });

            _mapper = config.CreateMapper();

            _handler = new UpdateSaleHandler(
                _saleRepository,
                _userRepository,
                _branchRepository,
                _productRepository,
                _mapper,
                _eventRepositoryFactory,
                _eventPublisherFactory
                
            );
        }

        [Fact]
        public async Task Handle_ValidCommand_ShouldUpdateSale()
        {
            // Arrange
            var saleId = Guid.NewGuid();
            var command = UpdateSaleHandlerTestData.ValidCommand(saleId);
            var user = UpdateSaleHandlerTestData.ValidUser(command.CustomerId);
            var branch = UpdateSaleHandlerTestData.ValidBranch(command.BranchId);
            var existingSale = UpdateSaleHandlerTestData.ExistingSale(saleId, command.CustomerId, command.BranchId, command.Items);

            _saleRepository.GetByIdAsync(saleId, Arg.Any<CancellationToken>()).Returns(existingSale);
            _userRepository.GetByIdAsync(command.CustomerId, Arg.Any<CancellationToken>()).Returns(user);
            _branchRepository.GetByIdAsync(command.BranchId, Arg.Any<CancellationToken>()).Returns(branch);

            _productRepository.GetByIdAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>())
                .Returns(callInfo =>
                {
                    var productId = callInfo.Arg<Guid>();
                    var item = command.Items.FirstOrDefault(x => x.ProductId == productId);
                    return Task.FromResult(UpdateSaleHandlerTestData.ValidProduct(productId, item.UnitPrice));
                });

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(saleId);
            result.Items.Should().HaveCount(command.Items.Count);
        }

        [Fact]
        public async Task Handle_InvalidQuantity_ShouldThrowValidationException()
        {
            // Arrange
            var saleId = Guid.NewGuid();
            var command = UpdateSaleHandlerTestData.ValidCommand(saleId);
            command.Items[0].Quantity = 0;

            // Act
            Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

            // Assert
            await act.Should().ThrowAsync<FluentValidation.ValidationException>();
        }

        [Fact]
        public async Task Handle_SaleNotFound_ShouldThrowException()
        {
            // Arrange
            var command = UpdateSaleHandlerTestData.ValidCommand(Guid.NewGuid());

            _saleRepository.GetByIdAsync(command.Id, Arg.Any<CancellationToken>()).Returns((Sale)null);

            // Act
            Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

            // Assert
            await act.Should().ThrowAsync<Exception>()
                .WithMessage($"Sale {command.Id} not found."); 
        }
    }
}
