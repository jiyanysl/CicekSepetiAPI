using CicekSepetiAPI.Entity;

namespace CicekSepetiAPI.Models
{
    public class Cart: MongoDbEntity
    {
        public string UserId { get; set; }
        public string ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
