using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CoopManagementApp.Data;

namespace CoopManagementApp.Pages.Management
{
    public class IndexModel : PageModel
    {
        private readonly CoopManagementApp.Data.ManagementDbContext _context;

        public IndexModel(CoopManagementApp.Data.ManagementDbContext context)
        {
            _context = context;
        }

        public IList<Person> Person { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.People != null)
            {
                Person = await _context.People
                .Include(p => p.Address).ToListAsync();
            }
        }
    }
}
