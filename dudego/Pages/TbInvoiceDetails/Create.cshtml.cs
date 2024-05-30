using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using dudego.Models;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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
            var Cars= _context.TbCars.Select(c => new { Id = c.IdCar, Name = c.NumberPlate }).ToList();
            var invoiceNumber = _context.TbInvoices
                .OrderByDescending(i => i.IdInvoice)
                .Select(i => i.InvoiceNumber)
                .FirstOrDefault();
            ViewData["IdCar"] = new SelectList(Cars, "Id", "Name");
            ViewData["IdInvoice"] = invoiceNumber;
            //ViewData["IdInvoice"] = new SelectList(_context.TbInvoices, "IdInvoice", "IdInvoice");
            return Page();
        }
       // [BindProperty]
       public TbInvoiceDetail TbInvoiceDetail { get; set; } = default!;



public async Task<IActionResult> OnPostAsync([FromBody] List<TbInvoiceDetail> tbInvoiceDetails)
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        // Procesar los datos y guardar en la base de datos
        if (tbInvoiceDetails != null && tbInvoiceDetails.Any())
        {
            foreach (var item in tbInvoiceDetails)
            {
                _context.TbInvoiceDetails.Add(item);
            }

            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }





    /*  public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.TbInvoiceDetails.Add(TbInvoiceDetail);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
  */
}
}
