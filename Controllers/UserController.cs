using Microsoft.AspNetCore.Mvc;
using UserService.Models;

namespace UserService.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private static List<User> _users = new List<User>() {
         new () {
             Id = new Guid("c9fcbc4b-d2d1-4664-9079-dae78a1de446"),
             Name = "Henrik Fisker",
             Address1 = "Søndergade 3",
             City = "Harboøre",
             PostalCode = 7673,
             EmailAddress = "hnrk@afiskbutik.dk",
             PhoneNumber = "133466789"
         }
     };

    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }

    [HttpGet("{userId}", Name = "GetUserById")]
    public User Get(Guid userId)
    {
        return _users.Where(c => c.Id == userId).First();
    }
}
