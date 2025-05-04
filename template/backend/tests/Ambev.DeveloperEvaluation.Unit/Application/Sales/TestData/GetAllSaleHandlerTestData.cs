using System;
using System.Collections.Generic;
using Ambev.DeveloperEvaluation.Application.Sales.ListSale;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales.TestData
{
    public static class GetAllSaleHandlerTestData
    {
        /// <summary>
        /// Gera uma lista de vendas fictícias para testes.
        /// </summary>
        public static List<Sale> SampleSales()
        {
            var baseDate = DateTime.UtcNow.Date;
            return new List<Sale>
            {
                CreateSale(baseDate.AddDays(-2), Guid.NewGuid(), Guid.NewGuid(), false),
                CreateSale(baseDate.AddDays(-1), Guid.NewGuid(), Guid.NewGuid(), true),
                CreateSale(baseDate,             Guid.NewGuid(), Guid.NewGuid(), false)
            };
        }

        private static Sale CreateSale(DateTime date, Guid customerId, Guid branchId, bool isCancelled)
        {
            var sale = Sale.Create(
                customerId,
                "Cliente Teste",
                branchId,
                "Filial Teste",
                date,
                new[] { (Guid.NewGuid(), "Produto Teste", 100m, 2) }
            );

            sale.Id = Guid.NewGuid();
            sale.IsCancelled = isCancelled;
            return sale;
        }

        /// <summary>
        /// Query válida sem filtros adicionais (página 1, tamanho 10).
        /// </summary>
        public static GetAllSaleQuery ValidQuery(
            DateTime? startDate = null,
            DateTime? endDate = null,
            Guid? customerId = null,
            Guid? branchId = null,
            bool? isCancelled = null,
            int page = 1,
            int size = 10,
            string? order = null)
        {
            return new GetAllSaleQuery
            {
                StartDate = startDate,
                EndDate = endDate,
                CustomerId = customerId,
                BranchId = branchId,
                IsCancelled = isCancelled,
                Page = page,
                Size = size,
                Order = order
            };
        }

        /// <summary>
        /// Query com intervalo de datas inválido (StartDate após EndDate).
        /// </summary>
        public static GetAllSaleQuery InvalidDateRangeQuery()
        {
            var tomorrow = DateTime.UtcNow.Date.AddDays(1);
            var today = DateTime.UtcNow.Date;
            return ValidQuery(startDate: tomorrow, endDate: today);
        }
    }
}
