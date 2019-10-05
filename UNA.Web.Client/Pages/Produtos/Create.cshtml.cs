using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using UNA.Web.Client.Context;
using UNA.Web.Client.Model;

namespace UNA.Web.Client.Pages.Produtos
{
    public class CreateModel : PageModel
    {
        private readonly UNA.Web.Client.Context.CustomContext _context;

        public CreateModel(UNA.Web.Client.Context.CustomContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["Idcategoria"] = new SelectList(_context.CategoriaSet, "IdCategoria", "DescricaoCategoria");
        ViewData["IdUnidadeMedida"] = new SelectList(_context.UnidadeMedidaSet, "IdUnidadeMedida", "NomeUnidadeMedida");
            return Page();
        }

        [BindProperty]
        public Produto Produto { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ProdutoSet.Add(Produto);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}