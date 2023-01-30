using System;
using System.Collections.Generic;
using System.Linq;
using Ventas.Models;
using Ventas.Models.Request;

namespace Ventas.Services
{
    public class ClienteService : IClienteService
    {
        public void Add(ClienteRequest model)
        {
            using (VentasContext db = new VentasContext())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        Cliente cliente = new Cliente();
                        cliente.Nombre = model.Nombre;
                        db.Cliente.Add(cliente);
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
        public void Edit(ClienteRequest model)
        {
            using (VentasContext db = new VentasContext())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        Cliente cliente = db.Cliente.Find(model.Id);
                        cliente.Nombre = model.Nombre;
                        db.Entry(cliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw new Exception("Ocurrio un error al editar el cliente");
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
                        Cliente cliente = db.Cliente.Find(Id);
                        db.Remove(cliente);
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw new Exception("Ocurrio un error al eliminar el cliente");
                    }
                }
            }

        }


        public List<Cliente> Get()
        {
            using (VentasContext db = new VentasContext())
            {
                var list = db.Cliente.OrderByDescending(d => d.Id).ToList();

                return list;
            }
        }
    }
}

