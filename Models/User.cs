using CicekSepetiAPI.Entity;
using System.Text.Json.Serialization;

namespace CicekSepetiAPI.Models
{
    public class User: MongoDbEntity
    {
        public string UserName { get; set; }
        [JsonIgnore]//prevent password from being serialized
        public string Password { get; set; }
    }
}
