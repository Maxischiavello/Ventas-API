using System.Collections.Generic;
using Ventas.Models;
using Ventas.Models.Request;

namespace Ventas.Services
{
    public interface IClienteService
    {
        public List<Cliente> Get();
        public void Add(ClienteRequest model);
        public void Edit(ClienteRequest model);
        public void Delete(int Id);
    }
}
