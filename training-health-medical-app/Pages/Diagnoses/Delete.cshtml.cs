using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using training_health_medical_app.Data;
using training_health_medical_app.Model;

namespace training_health_medical_app.Pages.Diagnoses
{
    public class DeleteModel : PageModel
    {
        private readonly training_health_medical_app.Data.ApplicationDbContext _context;

        public DeleteModel(training_health_medical_app.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Diagnosis Diagnosis { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Diagnosis == null)
            {
                return NotFound();
            }

            var diagnosis = await _context.Diagnosis.FirstOrDefaultAsync(m => m.ID == id);

            if (diagnosis == null)
            {
                return NotFound();
            }
            else 
            {
                Diagnosis = diagnosis;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Diagnosis == null)
            {
                return NotFound();
            }
            var diagnosis = await _context.Diagnosis.FindAsync(id);

            if (diagnosis != null)
            {
                Diagnosis = diagnosis;
                _context.Diagnosis.Remove(Diagnosis);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
