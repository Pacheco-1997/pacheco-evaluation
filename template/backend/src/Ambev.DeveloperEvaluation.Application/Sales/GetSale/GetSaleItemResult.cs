using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale
{
    public class GetSaleItemResult
    {
        public Guid ProductId { get; set; }
        public string ProductTitle { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }
        public decimal ItemTotal { get; set; }
        public bool IsCancelled { get; set; }
    }
}
