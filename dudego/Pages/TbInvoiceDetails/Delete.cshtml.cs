using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using dudego.Models;

namespace dudego.Pages.TbInvoiceDetails
{
    public class DeleteModel : PageModel
    {
        private readonly dudego.Models.ModelContext _context;

        public DeleteModel(dudego.Models.ModelContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TbInvoiceDetail TbInvoiceDetail { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbinvoicedetail = await _context.TbInvoiceDetails.FirstOrDefaultAsync(m => m.IdInvoiceDetails == id);

            if (tbinvoicedetail == null)
            {
                return NotFound();
            }
            else
            {
                TbInvoiceDetail = tbinvoicedetail;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbinvoicedetail = await _context.TbInvoiceDetails.FindAsync(id);
            if (tbinvoicedetail != null)
            {
                TbInvoiceDetail = tbinvoicedetail;
                _context.TbInvoiceDetails.Remove(TbInvoiceDetail);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
