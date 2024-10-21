using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("user")]
public class UserController : ControllerBase
{
    [HttpGet("all")]
    public ActionResult All()
        => Ok(new object[] {
            new {
                Id = 1,
                Name = "John Doe",
                Email = "john@email.com"
            }
        });

    [HttpGet("me")]
    public ActionResult Me()
        => Ok(new
        {
            Id = 1,
            Name = "John Doe",
            Email = "john@email.com"
        });
}
