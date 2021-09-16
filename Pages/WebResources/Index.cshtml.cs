using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using laba1.Data;
using laba1.Models;

namespace laba1.Pages.WebResources
{
    public class IndexModel : PageModel
    {
        private readonly laba1.Data.laba1Context _context;

        public IndexModel(laba1.Data.laba1Context context)
        {
            _context = context;
        }

        public IList<WebPage> WebPage { get;set; }

        public async Task OnGetAsync()
        {
            WebPage = await _context.WebPage.ToListAsync();
        }
    }
}
