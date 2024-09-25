namespace TechFixBackend.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Manufacturer { get; set; }

        // New property to store image
        public byte[] Image { get; set; }
    }
}
