using System;
using System.Collections.Generic;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales.TestData
{
    public static class GetSaleHandlerTestData
    {
        public static GetSaleQuery ValidQuery(Guid id)
        {
            return new GetSaleQuery { Id = id };
        }

        public static GetSaleQuery InvalidQuery()
        {
            return new GetSaleQuery { Id = Guid.Empty };
        }

        public static Sale ValidSale(Guid id)
        {
            return new Sale
            {
                Id = id,
                SaleDate = DateTime.UtcNow,
                CustomerId = Guid.NewGuid(),
                CustomerName = "Cliente Teste",
                BranchId = Guid.NewGuid(),
                BranchName = "Filial Teste",
                IsCancelled = false,
                Items = new List<SaleItem>
                {
                    new SaleItem
                    {
                        ProductId = Guid.NewGuid(),
                        ProductTitle = "Produto 1",
                        UnitPrice = 10.0m,
                        Quantity = 2,
                        Discount = 0.0m,
                        IsCancelled = false
                    },
                    new SaleItem
                    {
                        ProductId = Guid.NewGuid(),
                        ProductTitle = "Produto 2",
                        UnitPrice = 20.0m,
                        Quantity = 1,
                        Discount = 0.0m,
                        IsCancelled = false
                    }
                }
            };
        }
    }
}
