using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Common.SharedModels
{
    public class Attachment
    {
        public string Id { get; set; }
        public string TargetType { get; set; } // "Task" or "Comment"
        public string TargetId { get; set; }
        public string UploadedBy { get; set; }
        public string FileName { get; set; }
        public string FileUrl { get; set; }
        public string FileType { get; set; }
        public long SizeInBytes { get; set; }
        public DateTime UploadedAt { get; set; }
    }
}
