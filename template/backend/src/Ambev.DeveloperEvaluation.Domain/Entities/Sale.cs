using System;
using System.Collections.Generic;
using System.Linq;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Common.Security;
using Microsoft.AspNetCore.Identity;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Representa uma venda no sistema, agregando itens de venda e aplicando regras de negócio.
    /// </summary>
    public class Sale : BaseEntity, ISale
    {
        /// <summary>
        /// Data e hora em que a venda foi realizada.
        /// </summary>
        public DateTime SaleDate { get; private set; }

        /// <summary>
        /// Identidade externa do cliente (clienteId) e desnormalização do nome.
        /// </summary>
        public Guid CustomerId { get; private set; }
        public string CustomerName { get; private set; } = string.Empty;

        /// <summary>
        /// Identidade externa da filial (branchId) e desnormalização do nome.
        /// </summary>
        public Guid BranchId { get; private set; }
        public string BranchName { get; private set; } = string.Empty;

        /// <summary>
        /// Total bruto antes de descontos.
        /// </summary>
        public decimal Subtotal { get; private set; }

        /// <summary>
        /// Valor total após aplicação de descontos.
        /// </summary>
        public decimal Total { get; private set; }

        /// <summary>
        /// Itens que compõem a venda.
        /// </summary>
        public List<SaleItem> Items { get; private set; } = new();

        IReadOnlyCollection<ISaleItem> ISale.Items => Items.AsReadOnly();

        /// <summary>
        /// Indica se a venda foi cancelada.
        /// </summary>
        public bool IsCancelled { get; private set; }

        public Sale()
        {
            // Para EF Core
        }

        /// <summary>
        /// Cria uma nova venda com itens, aplicando descontos e calculando totais.
        /// </summary>
        public static Sale Create(Guid customerId, string customerName,
                                  Guid branchId, string branchName,
                                  IEnumerable<(Guid productId, string productTitle, decimal unitPrice, int quantity)> products)
        {
            var sale = new Sale
            {
                SaleDate = DateTime.UtcNow,
                CustomerId = customerId,
                CustomerName = customerName,
                BranchId = branchId,
                BranchName = branchName
            };

            foreach (var p in products)
            {
                sale.AddItem(p.productId, p.productTitle, p.unitPrice, p.quantity);
            }
            sale.CalculateTotals();
            return sale;
        }

        private void AddItem(Guid productId, string productTitle, decimal unitPrice, int quantity)
        {
            if (quantity < 1)
                throw new InvalidOperationException("Quantity must be at least 1");
            if (quantity > 20)
                throw new InvalidOperationException("Cannot sell more than 20 identical items.");

            var item = new SaleItem(productId, productTitle, unitPrice, quantity);
            Items.Add(item);
        }

        private void CalculateTotals()
        {
            Subtotal = Items.Sum(i => i.TotalItemAmount);
            Total = Items.Sum(i => i.ItemTotalAfterDiscount);
        }

        /// <summary>
        /// Cancela a venda inteira.
        /// </summary>
        public void Cancel()
        {
            IsCancelled = true;
            foreach (var item in Items)
                item.Cancel();
        }

        public ValidationResultDetail Validate()
        {
            var validator = new SaleValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(e => (ValidationErrorDetail)e)
            };
        }
    }
}