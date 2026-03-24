using Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace Domain.Model;

public class University : Base<int>
{
    [MaxLength(200)]
    public string Name { get; set; } = string.Empty;
    [MaxLength(200)]
    public string Description { get; set; } = string.Empty;
    public Address Address { get; set; } = new();
    public List<Faculty> Faculties { get; set; } = new();
}
