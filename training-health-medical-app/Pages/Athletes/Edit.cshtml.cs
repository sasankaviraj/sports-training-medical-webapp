using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using training_health_medical_app.Data;
using training_health_medical_app.Model;

namespace training_health_medical_app.Pages.Athletes
{
    public class EditModel : PageModel
    {
        private readonly training_health_medical_app.Data.ApplicationDbContext _context;

        public EditModel(training_health_medical_app.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Athlete Athlete { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Athlete == null)
            {
                return NotFound();
            }

            var athlete =  await _context.Athlete.FirstOrDefaultAsync(m => m.ID == id);
            if (athlete == null)
            {
                return NotFound();
            }
            Athlete = athlete;
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

            _context.Attach(Athlete).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AthleteExists(Athlete.ID))
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

        private bool AthleteExists(int id)
        {
          return (_context.Athlete?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
