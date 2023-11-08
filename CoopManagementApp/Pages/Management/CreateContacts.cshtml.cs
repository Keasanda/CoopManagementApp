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
    public class CreateContactsModel : PageModel
    {
        private readonly CoopManagementApp.Data.ManagementDbContext _context;

        public CreateContactsModel(CoopManagementApp.Data.ManagementDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CompanyID"] = new SelectList(_context.Companies, "CompanyID", "CompanyName");
        ViewData["PersonID"] = new SelectList(_context.People, "PersonID", "Email");
            return Page();
        }

        [BindProperty]
        public Contact Contact { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Contacts == null || Contact == null)
            {
                return Page();
            }

            _context.Contacts.Add(Contact);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
