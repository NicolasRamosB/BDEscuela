using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBEducacionIT.Models
{
    [Table("Tipo")]
    public class Tipo
    {
        [Key]
        public int IDTipo { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(10)]
        [Required]
        public string Nombre { get; set; }

        public List<Evaluacion> Evaluacion { get; set; }

    }
}
