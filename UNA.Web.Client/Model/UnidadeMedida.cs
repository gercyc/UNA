using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UNA.Web.Client.Model
{
    [Table("UnidadeMedida")]
    public class UnidadeMedida
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Unidade de Medida")]
        public int IdUnidadeMedida { get; set; }
        public string CodUnidadeMedida { get; set; }
        public string NomeUnidadeMedida { get; set; }
        public override string ToString()
        {
            return CodUnidadeMedida;
        }
    }
}
