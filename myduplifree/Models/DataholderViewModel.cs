using System.ComponentModel.DataAnnotations;

namespace myduplifree.Models;

public class DataholderViewModel

{
    [Key]

    public int? Id { get; set; }
    public string? Name { get; set; }

    public int? Rownumber { get; set; }


    // public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}
