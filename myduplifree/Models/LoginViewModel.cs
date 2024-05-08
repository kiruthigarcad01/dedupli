using System.ComponentModel.DataAnnotations;

namespace myduplifree.Models;

public class LoginViewModel

{
    [Key]

    public int? id { get; set; }
    public string? Username { get; set; }

    public string? Password  { get; set; }

    // public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}
