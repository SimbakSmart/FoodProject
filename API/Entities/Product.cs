using System.Text.Json.Serialization;

namespace API.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Detail { get; set; } = default!;
        public string ImageUrl { get; set; } = default!;
        public double Price { get; set; }
        public bool IsPopularProduct { get; set; }

        public Category Category { get; set; } = default!;
        public int CategoryId { get; set; }

    }
}
