using Domain.Base;

namespace Domain.Model;

public class User : Base<int>
{

    public string Username { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
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
