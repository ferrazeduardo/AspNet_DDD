using Domain.DTO;
using Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace applicatioon.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{

    [AllowAnonymous]
    [HttpPost]
    public async Task<object> LoginUsuario([FromBody] LoginDTO loginDTO, [FromServices] ILoginService loginService)
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
