using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using dudego.Models;

namespace dudego.Pages.TbBranch
{
    public class DetailsModel : PageModel
    {
        private readonly dudego.Models.ModelContext _context;

        public DetailsModel(dudego.Models.ModelContext context)
        {
            _context = context;
        }

        public dudego.Models.TbBranch TbBranch { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbbranch = await _context.TbBranches.FirstOrDefaultAsync(m => m.IdBranch == id);
            if (tbbranch == null)
            {
                return NotFound();
            }
            else
            {
                TbBranch = tbbranch;
            }
            return Page();
        }
    }
}
