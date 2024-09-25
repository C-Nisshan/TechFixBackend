using System;

namespace TechFixBackend.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int SupplierId { get; set; }
        public int QuoteId { get; set; }
        public string PlacedBy { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public string Status { get; set; }

        // Navigation property for relationship
        public Supplier Supplier { get; set; }
        public Quote Quote { get; set; }
    }
}
