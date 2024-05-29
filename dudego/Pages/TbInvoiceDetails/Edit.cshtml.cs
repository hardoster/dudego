using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using dudego.Models;

namespace dudego.Pages.TbInvoiceDetails
{
    public class EditModel : PageModel
    {
        private readonly dudego.Models.ModelContext _context;

        public EditModel(dudego.Models.ModelContext context)
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

            var tbinvoicedetail =  await _context.TbInvoiceDetails.FirstOrDefaultAsync(m => m.IdInvoiceDetails == id);
            if (tbinvoicedetail == null)
            {
                return NotFound();
            }
            TbInvoiceDetail = tbinvoicedetail;
           ViewData["IdCar"] = new SelectList(_context.TbCars, "IdCar", "IdCar");
           ViewData["IdInvoice"] = new SelectList(_context.TbInvoices, "IdInvoice", "IdInvoice");
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

            _context.Attach(TbInvoiceDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbInvoiceDetailExists(TbInvoiceDetail.IdInvoiceDetails))
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

        private bool TbInvoiceDetailExists(decimal id)
        {
            return _context.TbInvoiceDetails.Any(e => e.IdInvoiceDetails == id);
        }
    }
}
