using System;

namespace TechFixBackend.Models
{
    public class Quote
    {
        public int QuoteId { get; set; }
        public int SupplierId { get; set; }
        public string RequestedBy { get; set; }
        public DateTime RequestDate { get; set; } = DateTime.UtcNow;
        public string Status { get; set; }

        // Navigation property for relationship
        public Supplier Supplier { get; set; }
    }
}
