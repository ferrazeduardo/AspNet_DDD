using Domain.DTO;
using Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace applicatioon.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{


    public async Task<object> Login([FromBody] LoginDTO loginDTO, [FromServices] ILoginService loginService)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        if (loginDTO == null)
        {
            return BadRequest();
        }

        try
        {
            var result = await loginService.FindByLogin(loginDTO);

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
