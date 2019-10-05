using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UNA.Web.Client.Context;
using UNA.Web.Client.Model;

namespace UNA.Web.Client.Pages.Produtos
{
    public class IndexModel : PageModel
    {
        private readonly UNA.Web.Client.Context.CustomContext _context;

        public IndexModel(UNA.Web.Client.Context.CustomContext context)
        {
            _context = context;
        }

        public IList<Produto> Produto { get;set; }

        public async Task OnGetAsync()
        {
            Produto = await _context.ProdutoSet
                .Include(p => p.Categoria)
                .Include(p => p.UnidadeMedida).ToListAsync();
        }
    }
}
