using System.Collections.Generic;
using Ventas.Models;
using Ventas.Models.Request;

namespace Ventas.Services
{
    public interface IProductoService
    {
        public List<Producto> Get();
        public void Add(ProductoRequest model);
        public void Edit(ProductoRequest model);
        public void Delete(int Id);
    }
}
