using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CRUD2.Data;

namespace CRUD2.Pages.Emps
{
    public class CreateModel : PageModel
    {
        private readonly CRUD2.Data.ApplicationDbContext _context;

        public CreateModel(CRUD2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DID"] = new SelectList(_context.Departments, "DID", "DID");
            return Page();
        }

        [BindProperty]
        public Employees Employees { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Employees.Add(Employees);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}