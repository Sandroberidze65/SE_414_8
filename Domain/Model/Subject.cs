using Domain.Base;

namespace Domain.Model;

public class Subject : Base<int>
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<Student> Students { get; set; } = new();
}
