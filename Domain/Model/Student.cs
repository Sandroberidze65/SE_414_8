using Domain.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Model;

public class Student : Base<int>
{

    public string Studentname { get; set; }
    public string Lastname { get; set; }
    public int Age { get; set; }
    public int? AddressId { get; set; }
    public Address? Address { get; set; }
    public List<Subject> Subjects { get; set; }
}

public static class StudentExtentions
{
    public static void TestExtention(this Student student)
    {

    }

    public static void TestExtention(this Student student, int procent)
    {

    }
}