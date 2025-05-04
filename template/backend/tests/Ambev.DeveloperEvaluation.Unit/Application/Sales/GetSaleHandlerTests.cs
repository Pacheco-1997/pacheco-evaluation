using System;
using System.Threading;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Unit.Application.Sales.TestData;
using AutoMapper;
using FluentAssertions;
using FluentValidation;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales
{
    public class GetSaleHandlerTests
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;
        private readonly GetSaleHandler _handler;

        public GetSaleHandlerTests()
        {
            _saleRepository = Substitute.For<ISaleRepository>();

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<Ambev.DeveloperEvaluation.Application.Common.Mappings.GetSaleApplicationProfile>();
            });
            _mapper = configuration.CreateMapper();

            _handler = new GetSaleHandler(_saleRepository, _mapper);
        }

        [Fact]
        public async Task Handle_ValidQuery_ShouldReturnSale()
        {
            // Arrange
            var saleId = Guid.NewGuid();
            var query = GetSaleHandlerTestData.ValidQuery(saleId);
            var sale = GetSaleHandlerTestData.ValidSale(saleId);
            _saleRepository.GetByIdAsync(saleId, Arg.Any<CancellationToken>()).Returns(sale);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result!.Id.Should().Be(saleId);
            result.CustomerName.Should().Be(sale.CustomerName);
            result.BranchName.Should().Be(sale.BranchName);
            result.Items.Should().HaveCount(sale.Items.Count);
        }

        [Fact]
        public async Task Handle_InvalidQuery_ShouldThrowValidationException()
        {
            // Arrange
            var query = GetSaleHandlerTestData.InvalidQuery();

            // Act
            Func<Task> act = async () => await _handler.Handle(query, CancellationToken.None);

            // Assert
            await act.Should().ThrowAsync<ValidationException>();
        }

        [Fact]
        public async Task Handle_SaleNotFound_ShouldReturnNull()
        {
            // Arrange
            var saleId = Guid.NewGuid();
            var query = GetSaleHandlerTestData.ValidQuery(saleId);
            _saleRepository.GetByIdAsync(saleId, Arg.Any<CancellationToken>()).Returns((Sale?)null);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            result.Should().BeNull();
        }
    }
}
