using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UNA.Web.Client.Model
{
 
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public string Ncm { get; set; }

        [ForeignKey("IdUnidadeMedida")]
        [Display(Name = "Unidade de Medida")]
        public virtual UnidadeMedida UnidadeMedida { get; set; }
        [Display(Name = "Unidade de Medida")]
        public int IdUnidadeMedida { get; set; }

        [ForeignKey("Idcategoria")]
        public virtual CategoriaProduto Categoria { get; set; }
        [Display(Name = "Categoria Produto")]
        public int Idcategoria { get; set; }

    }
}
