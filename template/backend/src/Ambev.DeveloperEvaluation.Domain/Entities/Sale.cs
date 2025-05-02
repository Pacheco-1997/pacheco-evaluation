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
        public DateTime SaleDate { get; set; }

        /// <summary>
        /// Identidade externa do cliente (clienteId) e desnormalização do nome.
        /// </summary>
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; } 

        /// <summary>
        /// Identidade externa da filial (branchId) e desnormalização do nome.
        /// </summary>
        public Guid BranchId { get; set; }
        public string BranchName { get; set; } 

        /// <summary>
        /// Total bruto antes de descontos.
        /// </summary>
        public decimal Subtotal { get; set; }

        /// <summary>
        /// Valor total após aplicação de descontos.
        /// </summary>
        public decimal Total { get; set; }

        /// <summary>
        /// Itens que compõem a venda.
        /// </summary>
        public List<SaleItem> Items { get; set; } = new();

        IReadOnlyCollection<ISaleItem> ISale.Items => Items.AsReadOnly();

        /// <summary>
        /// Indica se a venda foi cancelada.
        /// </summary>
        public bool IsCancelled { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public Sale()
        {
            // Para EF Core
        }

        /// <summary>
        /// Cria uma nova venda com itens, aplicando descontos e calculando totais.
        /// </summary>
        public static Sale Create(Guid customerId,
                                  string customerName,
                                  Guid branchId,
                                  string branchName,
                                  DateTime saleDate,
                                  IEnumerable<(Guid productId, string productTitle, decimal unitPrice, int quantity)> products)
        {
            var sale = new Sale
            {
                CustomerId = customerId,
                CustomerName = customerName,
                BranchId = branchId,
                BranchName = branchName,
                SaleDate = saleDate,
                CreatedAt = DateTime.UtcNow,
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

            var item = new SaleItem(productId, productTitle, unitPrice, quantity, DateTime.UtcNow);
            Items.Add(item);
        }

        private void CalculateTotals()
        {
            Subtotal = Items.Sum(i => i.TotalItemAmount);
            Total = Items.Sum(i => i.ItemTotalAfterDiscount);
        }

        public void Update(
    Guid customerId,
    string customerName,
    Guid branchId,
    string branchName,
    DateTime saleDate,
    bool isCancelled,
    IEnumerable<(Guid productId, string productTitle, decimal unitPrice, int quantity, bool isCancelled)> products)
        {
            CustomerId = customerId;
            CustomerName = customerName;
            BranchId = branchId;
            BranchName = branchName;
            SaleDate = saleDate;
            IsCancelled = isCancelled;

            foreach (var p in products)
            {
                var existingItem = Items.FirstOrDefault(i => i.ProductId == p.productId);
                if (existingItem != null)
                {
                    existingItem.Update(p.productTitle, p.unitPrice, p.quantity, p.isCancelled);
                }
                else
                {
                    AddItem(p.productId, p.productTitle, p.unitPrice, p.quantity);
                }
            }

            CalculateTotals();
            UpdatedAt = DateTime.UtcNow;
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