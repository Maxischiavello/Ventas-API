using Ventas.Models.Request;

namespace Ventas.Services
{
    public interface IVentaService
    {
        public void Add(VentaRequest model);
    }
}
