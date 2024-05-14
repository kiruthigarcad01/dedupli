using System.ComponentModel.DataAnnotations;

namespace myduplifree.Models;

public class KGCViewModel

{
    public string? Username { get; set; }
    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string? CSP { get; set; }

    [Key]


    public string? Generate_Keys { get; set; }


    // public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}
