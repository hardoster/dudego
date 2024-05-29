using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using dudego.Models;

namespace dudego.Pages.TbInvoiceDetails
{
    public class IndexModel : PageModel
    {
        private readonly dudego.Models.ModelContext _context;

        public IndexModel(dudego.Models.ModelContext context)
        {
            _context = context;
        }

        public IList<TbInvoiceDetail> TbInvoiceDetail { get;set; } = default!;

        public async Task OnGetAsync()
        {
            TbInvoiceDetail = await _context.TbInvoiceDetails
                .Include(t => t.IdCarNavigation)
                .Include(t => t.IdInvoiceNavigation).ToListAsync();
        }
    }
}
