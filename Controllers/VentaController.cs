using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using Ventas.Models.Request;
using Ventas.Models.Response;
using Ventas.Services;

namespace Ventas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VentaController : ControllerBase
    {
        private IVentaService _venta;

        public VentaController(IVentaService venta)
        {
            this._venta = venta;
        }

        [HttpPost]
        public IActionResult Add(VentaRequest model)
        {
            Response response = new Response();

            try
            {
                _venta.Add(model);
                response.Exito = 1;
            }
            catch (Exception exception)
            {
                response.Mensaje = exception.Message;
            }

            return Ok(response);
        }
    }
}
