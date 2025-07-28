using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCommunication.Infrastructure.MongoModels
{
    public class NotificationDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        public string Id { get; set; }

        [BsonElement("userid")]
        public string UserId { get; set; }

        [BsonElement("type")]
        public string Type { get; set; }

        [BsonElement("referenceid")]
        public string ReferenceId { get; set; }

        [BsonElement("message")]
        public string Message { get; set; }

        [BsonElement("isread")]
        public bool IsRead { get; set; }

        [BsonElement("createdat")]
        public DateTime CreatedAt { get; set; }
    }

}
