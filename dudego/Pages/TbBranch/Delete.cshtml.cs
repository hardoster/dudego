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
    public class DeleteModel : PageModel
    {
        private readonly dudego.Models.ModelContext _context;

        public DeleteModel(dudego.Models.ModelContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbbranch = await _context.TbBranches.FindAsync(id);
            if (tbbranch != null)
            {
                TbBranch = tbbranch;
                _context.TbBranches.Remove(TbBranch);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
