using Domain.Base;

namespace Domain.Model;

public class University : Base<int>
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Address Address { get; set; } = new();
    public List<Faculty> Faculties { get; set; } = new();
}
