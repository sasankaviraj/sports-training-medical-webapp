using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using training_health_medical_app.Data;
using training_health_medical_app.Model;

namespace training_health_medical_app.Pages.Athletes
{
    public class IndexModel : PageModel
    {
        private readonly training_health_medical_app.Data.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;  // Inject UserManager

        public IndexModel(training_health_medical_app.Data.ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;  // Initialize UserManager
        }

        public IList<Athlete> Athlete { get;set; } = default!;

        public async Task OnGetAsync()
        {
            // Get the current user
            var user = await _userManager.GetUserAsync(User);
            if (_context.Athlete != null && user != null)
            {
                Athlete = await _context.Athlete.ToListAsync();
            }
            else { 
                Athlete = new List<Athlete>();
            }
        }
    }
}
