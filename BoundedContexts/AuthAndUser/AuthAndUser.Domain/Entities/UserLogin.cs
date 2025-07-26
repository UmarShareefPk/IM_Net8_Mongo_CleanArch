using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthAndUser.Domain.Entities
{
    public class UserLogin
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("userId")]
        public string UserId { get; set; } = null!;
        
        [BsonElement("username")]
        public string Username { get; set; } = null!;
        
        [BsonElement("password")]        
        public string Password { get; set; }

        [BsonElement("HubId")]
        public string HubId { get; set; } = null!;

        [BsonElement("createDate")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]

        public DateTime CreateDate { get; set; }
     
    }
}