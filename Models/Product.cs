using CicekSepetiAPI.Entity;

namespace CicekSepetiAPI.Models
{
    public class Product: MongoDbEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
    }
}
