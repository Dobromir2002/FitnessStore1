namespace FitnessStore.Models
{
    public class Product
    {
        public string Id { get; set; } // MongoDB Id
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }

    public class Order
    {
        public string Id { get; set; } // MongoDB Id
        public List<Product> Products { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
    }
}