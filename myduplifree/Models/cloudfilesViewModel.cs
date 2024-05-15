using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace kgc.Models
{
    public class cloudfilesViewModel
    {

    public string? Username { get; set; }
    public string? Email { get; set; }

  public string? PhoneNumber { get; set; }

  public string? CSP { get; set; }

[Key]
  public string? Generate_Keys { get; set; }



    }
}