using System;
using System.ComponentModel.DataAnnotations;

namespace clouddata.Models
{
    public class DeduplicateViewModel
    {
        [Key]
        public int Id { get; set; }
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public string? FileHash { get; set; }
        public int? FileSize { get; set; }
        public DateTime? UploadDate { get; set; }
        public bool? IsDuplicate { get; set; }
    }
}
