using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CoopManagementApp.Data;

namespace CoopManagementApp.Pages.Management
{
    public class CreateCompaniesModel : PageModel
    {
        private readonly CoopManagementApp.Data.ManagementDbContext _context;

        public CreateCompaniesModel(CoopManagementApp.Data.ManagementDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AddressID"] = new SelectList(_context.Addresses, "AddressID", "AddressID");
            return Page();
        }

        [BindProperty]
        public Company Company { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Companies == null || Company == null)
            {
                return Page();
            }

            _context.Companies.Add(Company);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
