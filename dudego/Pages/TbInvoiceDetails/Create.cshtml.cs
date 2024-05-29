using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using dudego.Models;

namespace dudego.Pages.TbInvoiceDetails
{
    public class CreateModel : PageModel
    {
        private readonly dudego.Models.ModelContext _context;

        public CreateModel(dudego.Models.ModelContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {

        var invoice = _context.TbInvoices.OrderByDescending(i => i.IdInvoice).FirstOrDefault()?.IdInvoice ?? 0;


       ViewData["IdCar"] = new SelectList(_context.TbCars, "IdCar", "IdCar");
            ViewData["IdInvoice"] = invoice;
            //ViewData["IdInvoice"] = new SelectList(_context.TbInvoices, "IdInvoice", "IdInvoice");
            return Page();
        }

        [BindProperty]
        public TbInvoiceDetail TbInvoiceDetail { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TbInvoiceDetails.Add(TbInvoiceDetail);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
