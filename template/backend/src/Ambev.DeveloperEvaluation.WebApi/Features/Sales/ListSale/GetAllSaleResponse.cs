namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.ListSale;

    public class GetAllSaleResponse
    {
        public Guid Id { get; set; }
        public DateTime SaleDate { get; set; }

        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }

        public Guid BranchId { get; set; }
        public string BranchName { get; set; }

        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
        public decimal TotalAmount { get; set; } // Soma dos itens, incluindo descontos

        public bool IsCancelled { get; set; }

        public List<GetAllSaleItemResponse> Items { get; set; } = new();
    }

