using System.ComponentModel.DataAnnotations;

namespace myduplifree.Models
{
    public class UploadfileViewModel
    {
        [Key]
        public int? UserID { get; set; }

        public  string FileName { get; set; }

        public long Size { get; set; }

        public required string Format { get; set; }

        public required string StoragePath { get; set; }

        // Additional properties or methods can be added as needed
    }
}
