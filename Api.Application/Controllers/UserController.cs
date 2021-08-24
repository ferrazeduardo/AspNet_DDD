using Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace applicatioon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromServices] IUserService userService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {

            }
            catch (ArgumentException e)
            {
               return StatusCode((int) HttpStatusCode.InternalServerError,e.Message);
            }
        }
    }
}
