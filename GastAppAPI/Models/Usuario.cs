using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GastAppAPI.Models
{
    public class Usuario
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string Nombre_Usuario { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Mail { get; set; }
        public string FotoPerfil { get; set; }

    }
}
