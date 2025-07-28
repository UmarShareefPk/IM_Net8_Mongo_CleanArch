using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Shared.Persistence
{
    public class AttachmentDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        public string Id { get; set; }

        [BsonElement("targettype")]
        public string TargetType { get; set; } // "Task" or "Comment" or "Message" or "User"

        [BsonElement("targetid")]
        public string TargetId { get; set; }

        [BsonElement("uploadedby")]
        public string UploadedBy { get; set; }

        [BsonElement("filename")]
        public string FileName { get; set; }

        [BsonElement("fileurl")]
        public string FileUrl { get; set; }

        [BsonElement("filetype")]
        public string FileType { get; set; }

        [BsonElement("sizeinbytes")]
        public long SizeInBytes { get; set; }

        [BsonElement("uploadedat")]
        public DateTime UploadedAt { get; set; }
    }

}
