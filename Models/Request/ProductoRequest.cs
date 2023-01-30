using System;
using System.ComponentModel.DataAnnotations;

namespace Ventas.Models.Request
{
    public class ProductoRequest
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "El nombre del producto debe tener minimo 2 caracter")]
        [MaxLength(50, ErrorMessage = "El nombre del producto debe tener maximo 50 caracter")]
        public string Nombre { get; set; }

        [Required]
        [Range(1, Double.MaxValue, ErrorMessage = "El precio unitario debe ser mayor a 0")]
        public decimal PrecioUnitario { get; set; }

        [Required]
        [Range(1, Double.MaxValue, ErrorMessage = "El costo debe ser mayor a 0")]
        public decimal Costo { get; set; }
    }
}
