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
    public class IndexModel : PageModel
    {
        private readonly dudego.Models.ModelContext _context;

        public IndexModel(dudego.Models.ModelContext context)
        {
            _context = context;
        }

        public IList<dudego.Models.TbBranch> TbBranch { get;set; } = default!;

        public async Task OnGetAsync()
        {
            TbBranch = await _context.TbBranches.ToListAsync();
        }
    }
}
