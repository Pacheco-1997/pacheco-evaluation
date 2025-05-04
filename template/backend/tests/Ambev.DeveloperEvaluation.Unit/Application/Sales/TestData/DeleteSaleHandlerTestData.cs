using System;
using Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales.TestData
{
    public static class DeleteSaleHandlerTestData
    {
        public static DeleteSaleCommand ValidCommand(Guid saleId)
        {
            return new DeleteSaleCommand
            {
                Id = saleId
            };
        }

        public static DeleteSaleCommand InvalidCommand()
        {
            return new DeleteSaleCommand
            {
                Id = Guid.Empty
            };
        }
    }
}
