using System;
using System.ComponentModel.DataAnnotations;

namespace myduplifree.Models
{
    public class cloudfilesViewModel
    {
        
       

        public string?FileName { get; set; }

        public string? FileLocation { get; set; } // Change type to string for file paths

         public string? Publickey { get; set; }

        public DateTime? Updatedto { get; set; }

        public string? Youarein { get; set; }

        // Additional properties or methods can be added as needed
    }
}
