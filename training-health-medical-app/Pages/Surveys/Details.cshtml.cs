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
    public class DetailsModel : PageModel
    {
        private readonly training_health_medical_app.Data.ApplicationDbContext _context;

        public DetailsModel(training_health_medical_app.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
