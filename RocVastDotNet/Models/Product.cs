namespace RocVastDotNet.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Image { get; set; }
        public decimal Price { get; set; }
        public string? ShortDesc { get; set; }
        public int Quantity { get; set; }
        public string? Category { get; set; }
    }
}
