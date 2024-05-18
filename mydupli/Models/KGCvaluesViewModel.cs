using System.ComponentModel.DataAnnotations;

namespace mydupli.Models
{
    public class KGCvaluesViewModel
    {
        [Key]
        public int? UserID { get; set; }

        public string? FileName { get; set; }
        public string? Size { get; set; }
        public string? Format { get; set; }
        public string? StoragePath { get; set; }

        // public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
