using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Shared.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Infrastructure.MongoModels
{
    public class TaskItemDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        public string Id { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("status")]
        [BsonRepresentation(BsonType.String)]
        public TaskItemStatus Status { get; set; }

        [BsonElement("priority")]
        [BsonRepresentation(BsonType.String)]
        public TaskItemPriority Priority { get; set; }

        [BsonElement("createdby")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CreatedBy { get; set; }

        [BsonElement("assignedto")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? AssignedTo { get; set; }

        [BsonElement("duedate")]
        public DateTime? DueDate { get; set; }

        [BsonElement("createdat")]
        public DateTime CreatedAt { get; set; }

        [BsonElement("updatedat")]
        public DateTime UpdatedAt { get; set; }
    }
}
