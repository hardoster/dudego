using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using dudego.Models;

namespace dudego.Pages.TbBranch
{
    public class EditModel : PageModel
    {
        private readonly dudego.Models.ModelContext _context;

        public EditModel(dudego.Models.ModelContext context)
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

            var tbbranch =  await _context.TbBranches.FirstOrDefaultAsync(m => m.IdBranch == id);
            if (tbbranch == null)
            {
                return NotFound();
            }
            TbBranch = tbbranch;
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

            _context.Attach(TbBranch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbBranchExists(TbBranch.IdBranch))
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

        private bool TbBranchExists(decimal id)
        {
            return _context.TbBranches.Any(e => e.IdBranch == id);
        }
    }
}
