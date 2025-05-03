using Ambev.DeveloperEvaluation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Events
{
    public class SaleItemCancelledEvent
    {
        public SaleItem SaleItem { get; }

        public SaleItemCancelledEvent(SaleItem saleItem)
        {
            SaleItem = saleItem;
        }
    }
}
