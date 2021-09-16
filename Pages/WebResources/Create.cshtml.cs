using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using laba1.Data;
using laba1.Models;

namespace laba1.Pages.WebResources
{
    public class CreateModel : PageModel
    {
        private readonly laba1.Data.laba1Context _context;

        public CreateModel(laba1.Data.laba1Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public WebPage WebPage { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.WebPage.Add(WebPage);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
