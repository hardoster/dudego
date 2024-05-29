using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using dudego.Models;

namespace dudego.Pages.TbInvoice
{
    public class EditModel : PageModel
    {
        private readonly dudego.Models.ModelContext _context;

        public EditModel(dudego.Models.ModelContext context)
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

            var tbinvoice =  await _context.TbInvoices.FirstOrDefaultAsync(m => m.IdInvoice == id);
            if (tbinvoice == null)
            {
                return NotFound();
            }
            TbInvoice = tbinvoice;
           ViewData["IdBranch"] = new SelectList(_context.TbBranches, "IdBranch", "IdBranch");
           ViewData["IdCustomer"] = new SelectList(_context.TbCustomers, "IdCustomer", "IdCustomer");
           ViewData["IdSalesperson"] = new SelectList(_context.TbSalespeople, "IdSalesperson", "IdSalesperson");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TbInvoice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbInvoiceExists(TbInvoice.IdInvoice))
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

        private bool TbInvoiceExists(decimal id)
        {
            return _context.TbInvoices.Any(e => e.IdInvoice == id);
        }
    }
}
