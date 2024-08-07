using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GastAppAPI.Models
{
    public class Ingreso
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public float Importe { get; set; }

        [Required]
        public string Dia { get; set; }

        [Required]
        public string Mes { get; set; }

        [Required]
        public string Anio { get; set; }

        public int NombreIngresoId { get; set; }

        public int TipoIngresoId { get; set; }

        public string UsuarioId { get; set; }
        // Propiedades de navegación
    }
}
