using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthAndUser.Domain.Entities
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        [BsonElement("createDate")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;

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
        public string HubId { get; set; } = null!;
    }
}
