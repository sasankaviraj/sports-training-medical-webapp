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

namespace training_health_medical_app.Pages.Diagnoses
{
    public class EditModel : PageModel
    {
        private readonly training_health_medical_app.Data.ApplicationDbContext _context;

        public EditModel(training_health_medical_app.Data.ApplicationDbContext context)
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

            var diagnosis =  await _context.Diagnosis.FirstOrDefaultAsync(m => m.ID == id);
            if (diagnosis == null)
            {
                return NotFound();
            }
            Diagnosis = diagnosis;
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

            _context.Attach(Diagnosis).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiagnosisExists(Diagnosis.ID))
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

        private bool DiagnosisExists(int id)
        {
          return (_context.Diagnosis?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
