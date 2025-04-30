using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class SaleItem : BaseEntity, ISaleItem
    {
        public Guid SaleId { get; private set; }
        public Guid ProductId { get; private set; }
        public string ProductTitle { get; private set; } = string.Empty;
        public decimal UnitPrice { get; private set; }
        public int Quantity { get; private set; }
        public decimal Discount { get; private set; }
        public decimal TotalItemAmount => UnitPrice * Quantity;
        public decimal ItemTotalAfterDiscount => TotalItemAmount - Discount;
        public bool IsCancelled { get; private set; }

        protected SaleItem() { }

        public SaleItem(Guid productId, string productTitle, decimal unitPrice, int quantity)
        {
            ProductId = productId;
            ProductTitle = productTitle;
            UnitPrice = unitPrice;
            Quantity = quantity;
            ApplyDiscount();
        }

        private void ApplyDiscount()
        {
            if (Quantity >= 10 && Quantity <= 20)
                Discount = TotalItemAmount * 0.20m;
            else if (Quantity >= 4)
                Discount = TotalItemAmount * 0.10m;
            else
                Discount = 0;
        }

        public void Cancel() => IsCancelled = true;
    }
}
