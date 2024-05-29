using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using dudego.Models;

namespace dudego.Pages.TbCustomer
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
            return Page();
        }

        [BindProperty]
        public Models.TbCustomer TbCustomer { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TbCustomers.Add(TbCustomer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
