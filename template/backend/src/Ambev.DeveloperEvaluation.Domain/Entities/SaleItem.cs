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
        public Guid SaleId { get; set; }
        public Guid ProductId { get; set; }
        public string ProductTitle { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalItemAmount => UnitPrice * Quantity;
        public decimal ItemTotalAfterDiscount => TotalItemAmount - Discount;
        public bool IsCancelled { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
            
        public SaleItem() { }

        public SaleItem(Guid productId, string productTitle, decimal unitPrice, int quantity, DateTime createdAt)
        {
            ProductId = productId;
            ProductTitle = productTitle;
            UnitPrice = unitPrice;
            Quantity = quantity;
            CreatedAt = createdAt;
            ApplyDiscount();
        }

        public void Update(string productTitle, decimal unitPrice, int quantity, bool isCancelled)
        {
            ProductTitle = productTitle;
            UnitPrice = unitPrice;
            Quantity = quantity;
            IsCancelled = isCancelled;
            ApplyDiscount();
            UpdatedAt = DateTime.UtcNow;
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
