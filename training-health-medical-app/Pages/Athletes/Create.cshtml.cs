using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using training_health_medical_app.Data;
using training_health_medical_app.Model;

namespace training_health_medical_app.Pages.Athletes
{
    public class CreateModel : PageModel
    {
        private readonly training_health_medical_app.Data.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;  // Inject UserManager

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
        public Athlete Athlete { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            // Get the current user
            var user = await _userManager.GetUserAsync(User);

            if (!ModelState.IsValid || _context.Athlete == null || Athlete == null)
            {
                if (user == null)
                {
                    return RedirectToPage("/Account/Login", new { area = "Identity" });

                }
                return Page();
            }

            if (user != null)
            {
                Athlete.UserID = user.Id;
                _context.Athlete.Add(Athlete);
                await _context.SaveChangesAsync();
            }
            else {
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }

            return RedirectToPage("./Index");
        }
    }
}
