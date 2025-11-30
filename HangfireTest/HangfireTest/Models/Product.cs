namespace HangfireTest.Models
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public decimal price { get; set; }
        public int stock { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
