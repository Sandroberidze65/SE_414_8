using Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace Domain.Model;

public class User : Base<int>
{
    [MaxLength(200)]
    public string Username { get; set; }
    [MaxLength(200)]
    public string Firstname { get; set; }
    [MaxLength(200)]
    public string Lastname { get; set; }
    [MaxLength(200)]
    public string Email { get; set; }
    [MaxLength(200)]
    public string Password { get; set; }
    [MaxLength(200)]
    public string City { get; set; }

    public User(int id, string username, string firstname, string lastname, string email, string city, string password)
    {
        Id = id;
        Username = username;
        Firstname = firstname;
        Lastname = lastname;
        Email = email;
        City = city;
        Password = password;
    }


}
