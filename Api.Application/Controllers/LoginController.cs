using Domain.Entities;
using Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace applicatioon.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{


    public async Task<object> Login([FromBody] UserEntity userEntity, [FromServices] ILoginService loginService)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        if (userEntity == null)
        {
            return BadRequest();
        }

        try
        {
            var result = await loginService.FindByLogin(userEntity);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
        catch (ArgumentException e)
        {
            return StatusCode((int) HttpStatusCode.InternalServerError,e.Message); 
        }
    }
}
