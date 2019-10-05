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
    public class DetailsModel : PageModel
    {
        private readonly UNA.Web.Client.Context.CustomContext _context;

        public DetailsModel(UNA.Web.Client.Context.CustomContext context)
        {
            _context = context;
        }

        public Produto Produto { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Produto = await _context.ProdutoSet
                .Include(p => p.Categoria)
                .Include(p => p.UnidadeMedida).FirstOrDefaultAsync(m => m.IdProduto == id);

            if (Produto == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
