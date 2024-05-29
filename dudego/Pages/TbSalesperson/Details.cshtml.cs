using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using dudego.Models;

namespace dudego.Pages.TbSalesperson
{
    public class DetailsModel : PageModel
    {
        private readonly dudego.Models.ModelContext _context;

        public DetailsModel(dudego.Models.ModelContext context)
        {
            _context = context;
        }

        public Models.TbSalesperson TbSalesperson { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbsalesperson = await _context.TbSalespeople.FirstOrDefaultAsync(m => m.IdSalesperson == id);
            if (tbsalesperson == null)
            {
                return NotFound();
            }
            else
            {
                TbSalesperson = tbsalesperson;
            }
            return Page();
        }
    }
}
