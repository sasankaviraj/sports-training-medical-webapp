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
    public class IndexModel : PageModel
    {
        private readonly training_health_medical_app.Data.ApplicationDbContext _context;

        public IndexModel(training_health_medical_app.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Coach> Coach { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Coach != null)
            {
                Coach = await _context.Coach.ToListAsync();
            }
        }
    }
}
