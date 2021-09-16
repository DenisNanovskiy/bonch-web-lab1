using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using laba1.Data;
using laba1.Models;

namespace laba1.Pages.WebResources
{
    public class EditModel : PageModel
    {
        private readonly laba1.Data.laba1Context _context;

        public EditModel(laba1.Data.laba1Context context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(WebPage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WebPageExists(WebPage.ID))
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

        private bool WebPageExists(int id)
        {
            return _context.WebPage.Any(e => e.ID == id);
        }
    }
}
