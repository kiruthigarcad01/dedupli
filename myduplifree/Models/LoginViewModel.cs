using System.ComponentModel.DataAnnotations;

namespace myduplifree.Models;

public class LoginViewModel

{
    [Key]

    public int? UserID { get; set; }
    public string? Username { get; set; }

    public string? Password  { get; set; }

    // public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}
