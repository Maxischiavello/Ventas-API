using System;
using System.Collections.Generic;
using System.Linq;
using Ventas.Models;
using Ventas.Models.Request;

namespace Ventas.Services
{
    public class ProductoService : IProductoService
    {
        public void Add(ProductoRequest model)
        {
            using (VentasContext db = new VentasContext())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        Producto producto = new Producto();
                        producto.Nombre = model.Nombre;
                        producto.PrecioUnitario = model.PrecioUnitario;
                        producto.Costo = model.Costo;
                        db.Producto.Add(producto);
                        db.SaveChanges();
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
        public void Edit(ProductoRequest model)
        {
            using (VentasContext db = new VentasContext())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        Producto producto = db.Producto.Find(model.Id);
                        producto.Nombre = model.Nombre;
                        producto.PrecioUnitario= model.PrecioUnitario;
                        producto.Costo= model.Costo;
                        db.Entry(producto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw new Exception("Ocurrio un error al editar el producto");
                    }
                }
            }
        }

        public void Delete(int Id)
        {
            using (VentasContext db = new VentasContext())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        Producto producto = db.Producto.Find(Id);
                        db.Remove(producto);
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw new Exception("Ocurrio un error al eliminar el producto");
                    }
                }
            }

        }


        public List<Producto> Get()
        {
            using (VentasContext db = new VentasContext())
            {
                var list = db.Producto.OrderByDescending(d => d.Id).ToList();

                return list;
            }
        }
    }
}
