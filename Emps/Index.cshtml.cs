using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CRUD2.Data;

namespace CRUD2.Pages.Emps
{
    public class IndexModel : PageModel
    {
        private readonly CRUD2.Data.ApplicationDbContext _context;

        public IndexModel(CRUD2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Employees> Employees { get;set; }

        public async Task OnGetAsync()
        {
            Employees = await _context.Employees
                .Include(e => e.Depts).ToListAsync();
        }
    }
}
