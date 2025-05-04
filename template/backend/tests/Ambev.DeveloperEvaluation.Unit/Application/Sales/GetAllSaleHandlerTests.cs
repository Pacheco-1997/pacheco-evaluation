using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.Sales.ListSale;
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
    public class GetAllSaleHandlerTests
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;
        private readonly GetAllSaleHandler _handler;

        public GetAllSaleHandlerTests()
        {
            _saleRepository = Substitute.For<ISaleRepository>();
            var config = new MapperConfiguration(cfg => cfg.AddProfile<GetAllSaleApplicationProfile>());
            _mapper = config.CreateMapper();
            _handler = new GetAllSaleHandler(_saleRepository, _mapper);
        }

        [Fact]
        public async Task Handle_NoFilters_ReturnsAllSalesPaged()
        {
            // Arrange
            var sales = GetAllSaleHandlerTestData.SampleSales();
            _saleRepository.GetAllAsync(Arg.Any<CancellationToken>()).Returns(sales);
            var query = GetAllSaleHandlerTestData.ValidQuery();

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            result.Items.Should().HaveCount(sales.Count);
            result.TotalItems.Should().Be(sales.Count);
            result.CurrentPage.Should().Be(query.Page);
            result.TotalPages.Should().Be(1);
        }

        [Fact]
        public async Task Handle_FilterByCustomer_ReturnsMatchingSales()
        {
            // Arrange
            var sales = GetAllSaleHandlerTestData.SampleSales();
            _saleRepository.GetAllAsync(Arg.Any<CancellationToken>()).Returns(sales);
            var target = sales[1];
            var query = GetAllSaleHandlerTestData.ValidQuery(customerId: target.CustomerId);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            result.Items.Should().AllSatisfy(item => item.CustomerId.Should().Be(target.CustomerId));
            result.TotalItems.Should().Be(sales.Count(s => s.CustomerId == target.CustomerId));
        }

        [Fact]
        public async Task Handle_InvalidDateRange_ThrowsValidationException()
        {
            // Arrange
            var query = GetAllSaleHandlerTestData.InvalidDateRangeQuery();

            // Act
            Func<Task> act = () => _handler.Handle(query, CancellationToken.None);

            // Assert
            await act.Should().ThrowAsync<ValidationException>()
                .WithMessage("*StartDate must be earlier than or equal to EndDate.*");
        }

        [Fact]
        public async Task Handle_OrderDesc_SortsDescendingByDate()
        {
            // Arrange
            var sales = GetAllSaleHandlerTestData.SampleSales();
            _saleRepository.GetAllAsync(Arg.Any<CancellationToken>()).Returns(sales);
            var query = GetAllSaleHandlerTestData.ValidQuery(order: "SaleDate desc");

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            var dates = result.Items.Select(i => i.SaleDate).ToList();
            dates.Should().BeInDescendingOrder();
        }

        [Fact]
        public async Task Handle_Pagination_AppliesPageAndSize()
        {
            // Arrange
            var sales = new List<Sale>();
            for (int i = 0; i < 25; i++)
                sales.Add(GetAllSaleHandlerTestData.SampleSales()[0]);

            _saleRepository.GetAllAsync(Arg.Any<CancellationToken>()).Returns(sales);
            var query = GetAllSaleHandlerTestData.ValidQuery(page: 2, size: 10);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            result.Items.Should().HaveCount(10);
            result.CurrentPage.Should().Be(2);
            result.TotalPages.Should().Be((int)Math.Ceiling(25 / 10.0));
        }
    }
}
