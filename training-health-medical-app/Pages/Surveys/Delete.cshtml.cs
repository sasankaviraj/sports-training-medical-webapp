using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using training_health_medical_app.Data;
using training_health_medical_app.Model;

namespace training_health_medical_app.Pages.Surveys
{
    public class DeleteModel : PageModel
    {
        private readonly training_health_medical_app.Data.ApplicationDbContext _context;

        public DeleteModel(training_health_medical_app.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Survey Survey { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Survey == null)
            {
                return NotFound();
            }

            var survey = await _context.Survey.FirstOrDefaultAsync(m => m.ID == id);

            if (survey == null)
            {
                return NotFound();
            }
            else 
            {
                Survey = survey;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Survey == null)
            {
                return NotFound();
            }
            var survey = await _context.Survey.FindAsync(id);

            if (survey != null)
            {
                Survey = survey;
                _context.Survey.Remove(Survey);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
