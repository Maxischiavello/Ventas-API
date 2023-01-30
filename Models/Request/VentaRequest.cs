using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ventas.Models.Request
{
    public class VentaRequest
    {
        [Required]
        [Range(1, Double.MaxValue, ErrorMessage = "El valor IdCliente debe ser mayor a 0")]
        [ExisteCliente(ErrorMessage = "El cliente no existe")]
        public int IdCliente { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Debe haber minimo 1 concepto")]
        public List<Concepto> Conceptos { get; set; }

        public VentaRequest()
        {
            this.Conceptos = new List<Concepto>();
        }
    }

    public class Concepto
    {
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int IdProducto { get; set; }
    }

    #region Validaciones
    public class ExisteClienteAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int idCliente = (int)value;
            using (var db = new VentasContext())
            {
                if (db.Cliente.Find(idCliente) == null) return false;
            }
            return true;
        }
    }
    #endregion
}
