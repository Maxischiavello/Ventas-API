using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    public class ProductoController : ControllerBase
    {
        private IProductoService _productoService;
        public ProductoController(IProductoService productoService)
        {
            this._productoService = productoService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            Response response = new Response();

            try
            {
                var list = _productoService.Get();
                response.Exito = 1;
                response.Data = list;
            }
            catch (Exception exception)
            {
                response.Mensaje = exception.Message;
            }

            return Ok(response);
        }

        [HttpPost]
        public IActionResult Add(ProductoRequest model)
        {
            Response response = new Response();

            try
            {
                _productoService.Add(model);
                response.Exito = 1;
            }
            catch (Exception exception)
            {
                response.Mensaje = exception.Message;
            }

            return Ok(response);
        }

        [HttpPut]
        public IActionResult Edit(ProductoRequest model)
        {
            Response response = new Response();

            try
            {
                _productoService.Edit(model);
                response.Exito = 1;
            }
            catch (Exception exception)
            {
                response.Mensaje = exception.Message;
            }

            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            Response response = new Response();

            try
            {
                _productoService.Delete(Id);
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
