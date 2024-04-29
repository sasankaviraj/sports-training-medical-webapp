using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using training_health_medical_app.Data;
using training_health_medical_app.Model;

namespace training_health_medical_app.Pages.Coaches
{
    public class CreateModel : PageModel
    {
        private readonly training_health_medical_app.Data.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;  // Inject UserManager
        public bool CoachExists { get; private set; }
        public CreateModel(training_health_medical_app.Data.ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;  // Initialize UserManager
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Coach Coach { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            // Get the current user
            var user = await _userManager.GetUserAsync(User);

            if (!ModelState.IsValid || _context.Coach == null || Coach == null)
            {
                if (user == null)
                {
                    return RedirectToPage("/Account/Login", new { area = "Identity" });

                }
                return Page();
            }

            if (user != null)
            {
                var coach = await _context.Coach.FirstOrDefaultAsync(a => a.UserID == user.Id);
                if (coach == null) {
                    Coach.UserID = user.Id;
                    _context.Coach.Add(Coach);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    CoachExists = coach != null;
                    return Page();
                }
            }
            else
            {
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }

            return RedirectToPage("./Index");
        }
    }
}
