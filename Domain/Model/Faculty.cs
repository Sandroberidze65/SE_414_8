using Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace Domain.Model;

public class Faculty : Base<int>
{
    [MaxLength(200)]
    public string Name { get; set; } = string.Empty;
    [MaxLength(200)]
    public string Description { get; set; } = string.Empty ;
    public List<Student> Students { get; set; } = new();
}
