using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using dudego.Models;

namespace dudego.Pages.TbSalesperson
{
    public class EditModel : PageModel
    {
        private readonly dudego.Models.ModelContext _context;

        public EditModel(dudego.Models.ModelContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.TbSalesperson TbSalesperson { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbsalesperson =  await _context.TbSalespeople.FirstOrDefaultAsync(m => m.IdSalesperson == id);
            if (tbsalesperson == null)
            {
                return NotFound();
            }
            TbSalesperson = tbsalesperson;
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

            _context.Attach(TbSalesperson).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbSalespersonExists(TbSalesperson.IdSalesperson))
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

        private bool TbSalespersonExists(decimal id)
        {
            return _context.TbSalespeople.Any(e => e.IdSalesperson == id);
        }
    }
}
