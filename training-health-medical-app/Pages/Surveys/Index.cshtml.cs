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

namespace training_health_medical_app.Pages.Surveys
{
    public class IndexModel : PageModel
    {
        private readonly training_health_medical_app.Data.ApplicationDbContext _context;
        private readonly HttpClient _httpClient;  // Inject HttpClient
        private readonly UserManager<IdentityUser> _userManager;  // Inject UserManager

        public IndexModel(training_health_medical_app.Data.ApplicationDbContext context, IHttpClientFactory httpClientFactory, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _httpClient = httpClientFactory.CreateClient();  // Create HttpClient instance
            _userManager = userManager;  // Initialize UserManager
        }

        public IList<SurveyViewModel> Surveys { get; set; } = new List<SurveyViewModel>();

        public async Task OnGetAsync()
        {
            // Get the current user
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                // Retrieve Surveys from the database
                var surveys = await _context.Survey.Where(a => a.CoachID == user.Id).ToListAsync();

                foreach (var survey in surveys)
                {
                    // Find the Athlete corresponding to the PlayerID
                    var athlete = await _context.Athlete.FirstOrDefaultAsync(a => a.ID == Convert.ToInt32(survey.PlayerID));
                    // Find the Coach corresponding to the CoachID
                    var coach = await _context.Coach.FirstOrDefaultAsync(c => c.UserID == survey.CoachID);

                    // Create a view model to hold both Survey, Athlete, and Coach information
                    var surveyViewModel = new SurveyViewModel
                    {
                        Survey = survey,
                        AthleteName = athlete != null ? athlete.Name : "Unknown",
                        CoachName = coach != null ? coach.Name : "Unknown"
                    };

                    // Add the view model to the list
                    Surveys.Add(surveyViewModel);
                }

            }
            
        }
    }

    // ViewModel class to hold Survey and Athlete information together
    public class SurveyViewModel
    {
        public Survey Survey { get; set; }
        public string AthleteName { get; set; }
        public string CoachName { get; set; }
    }
}
