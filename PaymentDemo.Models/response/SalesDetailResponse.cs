namespace PaymentDemo.Models.response
{
    public class SalesDetailResponse
    {
        public int SaleId { get; set; }

        public string Description { get; set; } = null!;

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; } = null!;

        public int SaleDetailId { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal? Subtotal { get; set; }

    }
}
