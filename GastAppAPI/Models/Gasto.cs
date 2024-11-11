using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace GastAppAPI.Models
{
    public class Gasto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public float Importe { get; set; }
        public string Detalle { get; set; }

        [Required]
        public string Dia { get; set; }

        [Required]
        public string Mes { get; set; }

        [Required]
        public string Anio { get; set; }
        public int NombreGastoId { get; set; }
        public int TipoGastoId { get; set; }
        public string UsuarioId { get; set; }
        public int? Pagado { get; set; }
    }
}
