using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UNA.Web.Client.Model;

namespace UNA.Web.Client.Context
{
    public class CustomContext : DbContext
    {
        //o dbcontextOptions chega via injecao de dependencia da Startup.cs
        //as paginas do CRUD foram criadas via scaffold
        public CustomContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {
            
        }

        //entidades que a aplicacao vai trabalhar
        public DbSet<Produto> ProdutoSet { get; set; }
        public DbSet<CategoriaProduto> CategoriaSet { get; set; }
        public DbSet<UnidadeMedida> UnidadeMedidaSet { get; set; }

    }
}
