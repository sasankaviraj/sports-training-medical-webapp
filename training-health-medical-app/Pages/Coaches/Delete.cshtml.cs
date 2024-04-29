using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using training_health_medical_app.Data;
using training_health_medical_app.Model;

namespace training_health_medical_app.Pages.Coaches
{
    public class DeleteModel : PageModel
    {
        private readonly training_health_medical_app.Data.ApplicationDbContext _context;

        public DeleteModel(training_health_medical_app.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Coach Coach { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Coach == null)
            {
                return NotFound();
            }

            var coach = await _context.Coach.FirstOrDefaultAsync(m => m.ID == id);

            if (coach == null)
            {
                return NotFound();
            }
            else 
            {
                Coach = coach;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Coach == null)
            {
                return NotFound();
            }
            var coach = await _context.Coach.FindAsync(id);

            if (coach != null)
            {
                Coach = coach;
                _context.Coach.Remove(Coach);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
