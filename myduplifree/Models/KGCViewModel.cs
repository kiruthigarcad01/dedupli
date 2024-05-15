using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace myduplifree.Models
{
    public class KGCViewModel
    {
        [Key]
        public int? Id { get; set; }
         public string? FileName { get; set; }
          public string? FileLocation { get; set; }
           public string? Publickey { get; set; }
            public DateTime? Updatedto { get; set; }
               public int? Youarein { get; set; }
    }
}