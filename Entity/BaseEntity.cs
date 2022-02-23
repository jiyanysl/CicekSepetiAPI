using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace CicekSepetiAPI.Entity
{
    public class BaseEntity: IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string Id { get; set; }

        public DateTime CreatedAt => DateTime.Now;

    }
}
