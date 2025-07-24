using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Domain.Entities
{
    public class User
    {
        [BsonId]  
        [BsonRepresentation(BsonType.ObjectId)] // Allows using string instead of ObjectId type
        public string Id { get; set; } = default!;

        [BsonElement("email")]
        public string Email { get; set; } = default!;

        [BsonElement("passwordHash")]
        public string PasswordHash { get; set; } = default!;

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public User() { }

        public User(string email, string passwordHash)
        {
            Email = email;
            PasswordHash = passwordHash;
            CreatedAt = DateTime.UtcNow;
        }


    }
}
