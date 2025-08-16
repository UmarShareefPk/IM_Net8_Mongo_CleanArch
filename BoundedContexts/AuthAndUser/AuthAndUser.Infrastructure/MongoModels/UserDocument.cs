using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Shared.Common.Enums;
using System;


namespace AuthAndUser.Infrastructure.MongoModels
{
    public class UserDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("firstName")]
        public string FirstName { get; set; } = null!;

        [BsonElement("lastName")]
        public string LastName { get; set; } = null!;

        [BsonElement("profilePic")]
        public string ProfilePic { get; set; } = string.Empty;

        [BsonElement("email")]
        public string Email { get; set; } = null!;

        [BsonElement("phone")]
        public string Phone { get; set; } = string.Empty;

        [BsonRepresentation(BsonType.String)]
        [BsonElement("role")]
        public UserRole Role { get; set; }

        [BsonRepresentation(BsonType.Boolean)]
        [BsonElement("isActive")]
        public bool IsActive { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("teamId")]
        public string TeamId { get; set; } = null!;

        [BsonElement("createdAt")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [BsonElement("updatedAt")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
