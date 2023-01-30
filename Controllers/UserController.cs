using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ventas.Models.Request;
using Ventas.Models.Response;
using Ventas.Services;

namespace Ventas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Autentificar([FromBody] AuthRequest model)
        {
            Response response = new Response();

            var userResponse = _userService.Auth(model);

            if (userResponse == null)
            {
                response.Exito = 0;
                response.Mensaje = "Usuario o contraseña incorrecto";
                return BadRequest(response);
            }

            response.Exito = 1;
            response.Data = userResponse;

            return Ok(response);
        }
    }
}
