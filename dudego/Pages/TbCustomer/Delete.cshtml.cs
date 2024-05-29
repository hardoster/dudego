using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using dudego.Models;

namespace dudego.Pages.TbCustomer
{
    public class DeleteModel : PageModel
    {
        private readonly dudego.Models.ModelContext _context;

        public DeleteModel(dudego.Models.ModelContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.TbCustomer TbCustomer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbcustomer = await _context.TbCustomers.FirstOrDefaultAsync(m => m.IdCustomer == id);

            if (tbcustomer == null)
            {
                return NotFound();
            }
            else
            {
                TbCustomer = tbcustomer;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbcustomer = await _context.TbCustomers.FindAsync(id);
            if (tbcustomer != null)
            {
                TbCustomer = tbcustomer;
                _context.TbCustomers.Remove(TbCustomer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
