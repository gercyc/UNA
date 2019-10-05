using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UNA.Web.Client.Model
{
    [Table("CategoriaProduto")]
    public class CategoriaProduto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Categoria Produto")]
        public int IdCategoria { get; set; }
        public string CodigoCategoria { get; set; }
        public string DescricaoCategoria { get; set; }
        public override string ToString()
        {
            return DescricaoCategoria;
        }
    }
}
