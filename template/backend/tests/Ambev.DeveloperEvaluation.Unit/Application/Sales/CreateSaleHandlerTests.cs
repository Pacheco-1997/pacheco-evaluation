// CreateSaleHandlerTests.cs
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Application.Events;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Unit.Application.Sales.TestData;
using AutoMapper;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales
{
    public class CreateSaleHandlerTests
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IUserRepository _userRepository;
        private readonly IBranchRepository _branchRepository;
        private readonly IProductRepository _productRepository;
        private readonly IEventRepository<SaleCreatedEvent> _eventRepository;
        private readonly IEventRepositoryFactory _eventRepositoryFactory;
        private readonly IEventPublisherFactory _eventPublisherFactory;
        private readonly IMapper _mapper;
        private readonly CreateSaleHandler _handler;

        public CreateSaleHandlerTests()
        {
            _saleRepository = Substitute.For<ISaleRepository>();
            _userRepository = Substitute.For<IUserRepository>();
            _branchRepository = Substitute.For<IBranchRepository>();
            _productRepository = Substitute.For<IProductRepository>();
            _eventRepository = Substitute.For<IEventRepository<SaleCreatedEvent>>();

            // Mock factories
            _eventRepositoryFactory = Substitute.For<IEventRepositoryFactory>();
            _eventPublisherFactory = Substitute.For<IEventPublisherFactory>();
            _eventPublisherFactory.GetPublisher<SaleCreatedEvent>()
                .Returns(new LoggedEventPublisher<SaleCreatedEvent>(
                    _eventRepository,
                    Substitute.For<Microsoft.Extensions.Logging.ILogger<LoggedEventPublisher<SaleCreatedEvent>>>()
                ));

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Sale, CreateSaleResult>();
            });
            _mapper = config.CreateMapper();

            // Use correct variable names for constructor
            _handler = new CreateSaleHandler(
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
        public async Task Handle_ValidCommand_ShouldPersistSaleAndSaveEvent()
        {
            // Arrange
            var command = CreateSaleHandlerTestData.ValidCommand();
            var user = CreateSaleHandlerTestData.ValidUser(command.CustomerId);
            var branch = CreateSaleHandlerTestData.ValidBranch(command.BranchId);
            var item = command.Items.First();
            var product = CreateSaleHandlerTestData.ValidProduct(item.ProductId, item.UnitPrice);

            _userRepository.GetByIdAsync(command.CustomerId, Arg.Any<CancellationToken>())
                .Returns(Task.FromResult(user));
            _branchRepository.GetByIdAsync(command.BranchId, Arg.Any<CancellationToken>())
                .Returns(Task.FromResult(branch));
            _productRepository.GetByIdAsync(item.ProductId, Arg.Any<CancellationToken>())
                .Returns(Task.FromResult(product));

            _saleRepository.AddAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>())
                .Returns(Task.FromResult(0));

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            await _saleRepository.Received(1).AddAsync(
                Arg.Is<Sale>(s => s.CustomerId == command.CustomerId),
                Arg.Any<CancellationToken>());
            await _eventRepository.Received(1).SaveAsync(Arg.Any<SaleCreatedEvent>());
            result.Should().NotBeNull();
            result.Id.Should().NotBeEmpty();
        }
    }
}
