using System;
using System.Threading;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Unit.Application.Sales.TestData;
using FluentAssertions;
using FluentValidation;
using NSubstitute;
using Xunit;
using MediatRUnit = MediatR.Unit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales
{
    public class DeleteSaleHandlerTests
    {
        private readonly ISaleRepository _saleRepository;
        private readonly DeleteSaleHandler _handler;

        public DeleteSaleHandlerTests()
        {
            _saleRepository = Substitute.For<ISaleRepository>();
            _handler = new DeleteSaleHandler(_saleRepository);
        }

        [Fact]
        public async Task Handle_ValidCommand_ShouldDeleteSale()
        {
            // Arrange
            var saleId = Guid.NewGuid();
            var command = DeleteSaleHandlerTestData.ValidCommand(saleId);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            await _saleRepository.Received(1).DeleteAsync(saleId, Arg.Any<CancellationToken>());
            result.Should().Be(MediatRUnit.Value);
        }

        [Fact]
        public async Task Handle_InvalidCommand_ShouldThrowValidationException()
        {
            // Arrange
            var command = DeleteSaleHandlerTestData.InvalidCommand();

            // Act
            Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

            // Assert
            await act.Should().ThrowAsync<ValidationException>();
        }
    }
}
