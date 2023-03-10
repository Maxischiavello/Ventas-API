using System;
using System.Linq;
using Ventas.Models;
using Ventas.Models.Request;

namespace Ventas.Services
{
    public class VentaService : IVentaService
    {
        public void Add(VentaRequest model)
        {
            using (VentasContext db = new VentasContext())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var venta = new Venta();
                        venta.Total = model.Conceptos.Sum(d => d.Cantidad * d.PrecioUnitario);
                        venta.Fecha = DateTime.Now;
                        venta.IdCliente = model.IdCliente;
                        db.Venta.Add(venta);
                        db.SaveChanges();

                        foreach (var modelConcepto in model.Conceptos)
                        {
                            var concepto = new Models.Concepto();
                            concepto.Cantidad = modelConcepto.Cantidad;
                            concepto.IdProducto = modelConcepto.IdProducto;
                            concepto.PrecioUnitario = modelConcepto.PrecioUnitario;
                            concepto.IdVenta = venta.Id;
                            db.Concepto.Add(concepto);
                            db.SaveChanges();
                        }

                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw new Exception("Ocurrio un error en la inserción");
                    }
                }
            }
        }
    }
}
