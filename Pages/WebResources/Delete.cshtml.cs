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
    public class DeleteModel : PageModel
    {
        private readonly laba1.Data.laba1Context _context;

        public DeleteModel(laba1.Data.laba1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public WebPage WebPage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WebPage = await _context.WebPage.FirstOrDefaultAsync(m => m.ID == id);

            if (WebPage == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WebPage = await _context.WebPage.FindAsync(id);

            if (WebPage != null)
            {
                _context.WebPage.Remove(WebPage);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
