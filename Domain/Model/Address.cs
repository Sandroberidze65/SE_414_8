using Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace Domain.Model;

public class Address : Base<int>
{
    [MaxLength(200)]
    public string City { get; set; } = string.Empty;
    [MaxLength(200)]
    public string Country { get; set; } = string.Empty;
    [MaxLength(200)]
    public string Street { get; set; } = string.Empty;
    [MaxLength(200)]
    public string Zip { get; set; } = string.Empty;
}
