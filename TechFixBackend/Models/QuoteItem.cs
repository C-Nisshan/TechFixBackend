namespace TechFixBackend.Models
{
    public class QuoteItem
    {
        public int QuoteItemId { get; set; }
        public int QuoteId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        // Navigation properties for relationships
        public Quote Quote { get; set; }
        public Product Product { get; set; }
    }
}
