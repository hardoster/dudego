using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using dudego.Models;

namespace dudego.Pages.TbCar
{
    public class DetailsModel : PageModel
    {
        private readonly dudego.Models.ModelContext _context;

        public DetailsModel(dudego.Models.ModelContext context)
        {
            _context = context;
        }

        public Models.TbCar TbCar { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbcar = await _context.TbCars.FirstOrDefaultAsync(m => m.IdCar == id);
            if (tbcar == null)
            {
                return NotFound();
            }
            else
            {
                TbCar = tbcar;
            }
            return Page();
        }
    }
}
