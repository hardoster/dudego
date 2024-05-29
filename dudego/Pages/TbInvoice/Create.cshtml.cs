using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using dudego.Models;

namespace dudego.Pages.TbInvoice
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
            // Obtener la lista de clientes con sus nombres
            var clientes = _context.TbCustomers.Select(c => new { Id = c.IdCustomer, Name = c.NameCustomer }).ToList();
            var SalesPerson = _context.TbSalespeople.Select(c => new { Id = c.IdSalesperson, Name = c.NameSalesperson }).ToList();
           var Brach    = _context.TbBranches.Select(c => new {Id = c.IdBranch, Name = c.NameBranch }).ToList();

            ViewData["IdBranch"] = new SelectList(Brach, "Id", "Name");
           // ViewData["IdBranch"] = new SelectList(_context.TbBranches, "IdBranch", "IdBranch");
            ViewData["IdCustomer"] = new SelectList(clientes, "Id", "Name");
            //ViewData["IdCustomer"] = new SelectList(_context.TbCustomers, "IdCustomer", "NameCustomer");
            ViewData["IdSalesPerson"] = new SelectList(SalesPerson, "Id", "Name");
            // ViewData["IdSalesperson"] = new SelectList(_context.TbSalespeople, "IdSalesperson", "IdSalesperson");
            return Page();

        }

        [BindProperty]
        public Models.TbInvoice TbInvoice { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TbInvoices.Add(TbInvoice);
            await _context.SaveChangesAsync();

            return RedirectToPage("../TbInvoiceDetails/Create");
        }
    }
}
