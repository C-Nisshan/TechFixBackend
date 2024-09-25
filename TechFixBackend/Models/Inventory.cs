using System;

namespace TechFixBackend.Models
{
    public class Inventory
    {
        public int InventoryId { get; set; }
        public int SupplierId { get; set; }
        public int ProductId { get; set; }
        public int StockLevel { get; set; }
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;

        // Navigation properties for relationships
        public Supplier Supplier { get; set; }
        public Product Product { get; set; }
    }
}
