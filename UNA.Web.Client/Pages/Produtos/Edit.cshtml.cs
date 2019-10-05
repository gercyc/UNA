using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UNA.Web.Client.Context;
using UNA.Web.Client.Model;

namespace UNA.Web.Client.Pages.Produtos
{
    public class EditModel : PageModel
    {
        private readonly UNA.Web.Client.Context.CustomContext _context;

        public EditModel(UNA.Web.Client.Context.CustomContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["Idcategoria"] = new SelectList(_context.CategoriaSet, "IdCategoria", "DescricaoCategoria");
           ViewData["IdUnidadeMedida"] = new SelectList(_context.UnidadeMedidaSet, "IdUnidadeMedida", "NomeUnidadeMedida");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Produto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoExists(Produto.IdProduto))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProdutoExists(int id)
        {
            return _context.ProdutoSet.Any(e => e.IdProduto == id);
        }
    }
}
