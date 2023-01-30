using System.ComponentModel.DataAnnotations;

namespace Ventas.Models.Request
{
    public class ClienteRequest
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "El nombre debe tener minimo 2 caracter")]
        [MaxLength(50, ErrorMessage = "El nombre debe tener maximo 50 caracter")]
        public string Nombre { get; set; }
    }
}
