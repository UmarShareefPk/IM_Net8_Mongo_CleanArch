using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Infrastructure.MongoModels
{
    public class CommentDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        public string Id { get; set; }

        [BsonElement("taskid")]
        public string TaskId { get; set; }

        [BsonElement("userid")]
        public string UserId { get; set; }

        [BsonElement("text")]
        public string Text { get; set; }

        [BsonElement("createdat")]
        public DateTime CreatedAt { get; set; }
    }
}
