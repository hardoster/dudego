using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using dudego.Models;

namespace dudego.Pages.TbInvoice
{
    public class DeleteModel : PageModel
    {
        private readonly dudego.Models.ModelContext _context;

        public DeleteModel(dudego.Models.ModelContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.TbInvoice TbInvoice { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbinvoice = await _context.TbInvoices.FirstOrDefaultAsync(m => m.IdInvoice == id);

            if (tbinvoice == null)
            {
                return NotFound();
            }
            else
            {
                TbInvoice = tbinvoice;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbinvoice = await _context.TbInvoices.FindAsync(id);
            if (tbinvoice != null)
            {
                TbInvoice = tbinvoice;
                _context.TbInvoices.Remove(TbInvoice);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
