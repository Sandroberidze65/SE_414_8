using Domain.Model;
using Lection43.Options;
using Lection43.RequestModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Lection43.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(
    IOptions<AuthenticationOptions> options
) : ControllerBase
{
    private static List<User> _users = new()
    {
        new User(1,"alex123","Aleksandre","Mataradze","Alex@gmail.com", "Tbilisi", "1234" ),
        new User(2,"ilia321","Ilia","cocxalashvili","Ilia@gmail.com", "Tbilisi", "4321" ),
    };


    [HttpPost]
    public ActionResult<string> Authentificate(AuthentificationRequestBody requestBody)
    {
        var user = ValidateUserCreadentials(requestBody.Username, requestBody.Password);

        if (user == null)
        {
            return Unauthorized();
        }

        var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(options.Value.SecretKeyFor));

        var signinCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claimsForToken = new List<Claim>()
        {
            //new Claim("sub", user.Id.ToString()),   
            new Claim("firstname", user.Firstname),   
            new Claim("lastname", user.Lastname),   
            new Claim("city", user.City),   
        };

        var jwtSecurityToken = new JwtSecurityToken(
                options.Value.Issuer,
                options.Value.Audiance,
                claimsForToken,
                DateTime.Now,
                DateTime.Now.AddHours(1),
                signinCredentials
            );

        var tokenToReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

        return Ok(tokenToReturn);
    }

    private User ValidateUserCreadentials(string username, string password)
    {
        return _users.FirstOrDefault(u => u.Username.Equals(username) && u.Password.Equals(password));
    }
}
