using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;


namespace AuthAndUser.Infrastructure.MongoModels
{
    public class UserLoginDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        [BsonElement("userId")]
        public string UserId { get; set; } = null!;

        [BsonElement("username")]
        public string Username { get; set; } = null!;

        [BsonElement("passwordHash")]
        public string PasswordHash { get; set; } = null!;

        [BsonElement("passwordSalt")]
        public string PasswordSalt { get; set; } = null!;

        [BsonElement("hubId")]
        public string HubId { get; set; } = null!;

        [BsonElement("createDate")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
    }
}
