using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using dudego.Models;

namespace dudego.Pages.TbCar
{
    public class EditModel : PageModel
    {
        private readonly dudego.Models.ModelContext _context;

        public EditModel(dudego.Models.ModelContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.TbCar TbCar { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbcar =  await _context.TbCars.FirstOrDefaultAsync(m => m.IdCar == id);
            if (tbcar == null)
            {
                return NotFound();
            }
            TbCar = tbcar;
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

            _context.Attach(TbCar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbCarExists(TbCar.IdCar))
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

        private bool TbCarExists(decimal id)
        {
            return _context.TbCars.Any(e => e.IdCar == id);
        }
    }
}
