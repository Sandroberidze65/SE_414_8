using Domain.Base;

namespace Domain.Model;

public class Student : Base<int>
{
    public string Studentname { get; set; } = string.Empty;
    public string Lastname { get; set; } = string.Empty;
    public int Age { get; set; }
    public Address Address { get; set; } = new();
    public List<Subject> Subjects { get; set; } = new();
}
