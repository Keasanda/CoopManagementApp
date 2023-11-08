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
    public class CreateAdressModel : PageModel
    {
        private readonly CoopManagementApp.Data.ManagementDbContext _context;

        public CreateAdressModel(CoopManagementApp.Data.ManagementDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Address Address { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Addresses == null || Address == null)
            {
                return Page();
            }

            _context.Addresses.Add(Address);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
