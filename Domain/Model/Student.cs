using Domain.Base;
using System;

namespace Domain.Model;

public class Student : Base<int>
{
    public Student(string studentname, string lastname, int age)
    {
        Studentname = Char.ToUpper(studentname.First()) + studentname.Substring(1).ToLower();
        Lastname = Char.ToUpper(lastname.First()) + lastname.Substring(1).ToLower();
        Age = age;
        Address = new();
        Subjects = new();
    }

    public string Studentname { get;}
    public string Lastname { get; }
    public int Age { get; }
    public Address Address { get; set; }
    public List<Subject> Subjects { get; set; }
}
