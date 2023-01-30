using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Ventas.Models;
using Ventas.Models.Response;
using Ventas.Models.Request;
using Microsoft.AspNetCore.Authorization;
using Ventas.Services;

namespace Ventas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClienteController : ControllerBase
    {
        private IClienteService _clienteService;
        public ClienteController(IClienteService clienteService)
        {
            this._clienteService = clienteService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            Response response = new Response();

            try
            {
                var list = _clienteService.Get();
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
        public IActionResult Add(ClienteRequest model)
        {
            Response response = new Response();

            try
            {
                _clienteService.Add(model);
                response.Exito = 1;
            }
            catch (Exception exception)
            {
                response.Mensaje = exception.Message;
            }

            return Ok(response);
        }

        [HttpPut]
        public IActionResult Edit(ClienteRequest model)
        {
            Response response = new Response();

            try
            {
                _clienteService.Edit(model);
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
                _clienteService.Delete(Id);
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
