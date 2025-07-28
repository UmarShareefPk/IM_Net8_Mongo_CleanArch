using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCommunication.Infrastructure.MongoModels
{
    public class MessageDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        public string Id { get; set; }

        [BsonElement("senderid")]
        public string SenderId { get; set; }

        [BsonElement("receiverid")]
        public string ReceiverId { get; set; }

        [BsonElement("content")]
        public string Content { get; set; }

        [BsonElement("isread")]
        public bool IsRead { get; set; }

        [BsonElement("sentat")]
        public DateTime SentAt { get; set; }

        [BsonElement("readat")]
        public DateTime? ReadAt { get; set; }
    }
}
