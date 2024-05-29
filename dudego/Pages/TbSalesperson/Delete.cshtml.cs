using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using dudego.Models;

namespace dudego.Pages.TbSalesperson
{
    public class DeleteModel : PageModel
    {
        private readonly dudego.Models.ModelContext _context;

        public DeleteModel(dudego.Models.ModelContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.TbSalesperson TbSalesperson { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbsalesperson = await _context.TbSalespeople.FirstOrDefaultAsync(m => m.IdSalesperson == id);

            if (tbsalesperson == null)
            {
                return NotFound();
            }
            else
            {
                TbSalesperson = tbsalesperson;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbsalesperson = await _context.TbSalespeople.FindAsync(id);
            if (tbsalesperson != null)
            {
                TbSalesperson = tbsalesperson;
                _context.TbSalespeople.Remove(TbSalesperson);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
