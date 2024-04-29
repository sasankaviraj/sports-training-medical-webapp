using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using training_health_medical_app.Model;

namespace training_health_medical_app.Pages.Surveys
{
    public class CreateModel : PageModel
    {
        private readonly training_health_medical_app.Data.ApplicationDbContext _context;
        private readonly HttpClient _httpClient;  // Inject HttpClient
        private readonly UserManager<IdentityUser> _userManager;  // Inject UserManager
        public List<Athlete> Players { get; set; }
        public CreateModel(training_health_medical_app.Data.ApplicationDbContext context, IHttpClientFactory httpClientFactory, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _httpClient = httpClientFactory.CreateClient();  // Create HttpClient instance
            _userManager = userManager;  // Initialize UserManager
        }

  

        [BindProperty]
        public Survey Survey { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            Players = await _context.Athlete.ToListAsync() ?? new List<Athlete>();
            return Page();
        }
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            // Get the current user
            var user = await _userManager.GetUserAsync(User);
            if (!ModelState.IsValid || _context.Survey == null || Survey == null)
            {
                if (user == null)
                {
                    return RedirectToPage("/Account/Login", new { area = "Identity" });

                }
                return Page();
            }

            if (user != null)
            {
                // Get UserId of the current user
                var userId = user.Id;

                // Create an anonymous object with the "message" property
                var messageObject = new
                {
                    responses = new[]
                    {
                        new { question = "How would you describe your current mood?", answer = Survey.Mood },
                        new { question = "Have you experienced any significant changes in your appetite recently (increase or decrease)?", answer = Survey.Appetite },
                        new { question = "Are you experiencing feelings of sadness or hopelessness that persist over time?", answer = Survey.Feelings },
                        new { question = "Have you experienced a loss of interest in activities that once brought you pleasure?", answer = Survey.Interest },
                        new { question = "Have you noticed a change in your sleep patterns, such as difficulty falling asleep or waking up frequently during the night?", answer = Survey.Sleep },
                        new { question = "Are you experiencing physical symptoms such as headaches or stomachaches without a clear medical cause?", answer = Survey.PhysicalSymptom }
                    }
                };
                var jsonContent = JsonConvert.SerializeObject(messageObject);
                var stringContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                // Send POST request to the API
                var response = await _httpClient.PostAsync("http://127.0.0.1:5000/diagnose", stringContent);

                // Check if the API call was successful
                if (response.IsSuccessStatusCode)
                {
                    // Read response content as string
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    // Parse the JSON response to extract the value of the "response" property
                    var jsonResponse = JObject.Parse(apiResponse);
                    var diagnosis = jsonResponse["diagnosis"]?.ToString();
                    var treatment = jsonResponse["prescription"]?.ToString();

                    Survey.Treatment = treatment;
                    Survey.Diagnose = diagnosis;
                    Survey.CoachID = userId;
                    Survey.PlayerID = Survey.PlayerID;
                    _context.Survey.Add(Survey);
                    await _context.SaveChangesAsync();

                    return RedirectToPage("./Index");
                }
                else
                {
                    // Handle API call failure here
                    // For now, just return the page
                    return Page();
                }
            }
            else
            {
                // Handle API call failure here
                // For now, just return the page
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }
        }
    }
}
