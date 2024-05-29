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
    public class DetailsModel : PageModel
    {
        private readonly dudego.Models.ModelContext _context;

        public DetailsModel(dudego.Models.ModelContext context)
        {
            _context = context;
        }

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
    }
}
