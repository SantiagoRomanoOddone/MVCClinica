using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCClinica.Models
{
    [Table("Medico")]
    public class Medico
    {

        public int MedicoId { get; set; }
        [Required(ErrorMessage = "The Name field is required")]
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Apellido { get; set; }
        public int Matricula { get; set; }
        public int EspecialidadId { get; set; }
    }
}