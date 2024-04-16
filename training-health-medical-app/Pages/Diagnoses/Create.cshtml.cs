using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using training_health_medical_app.Data;
using training_health_medical_app.Model;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Identity;

namespace training_health_medical_app.Pages.Diagnoses
{
    public class CreateModel : PageModel
    {
        private readonly training_health_medical_app.Data.ApplicationDbContext _context;
        private readonly HttpClient _httpClient;  // Inject HttpClient
        private readonly UserManager<IdentityUser> _userManager;  // Inject UserManager

        public CreateModel(training_health_medical_app.Data.ApplicationDbContext context, IHttpClientFactory httpClientFactory, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _httpClient = httpClientFactory.CreateClient();  // Create HttpClient instance
            _userManager = userManager;  // Initialize UserManager
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Diagnosis Diagnosis { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            // Get the current user
            var user = await _userManager.GetUserAsync(User);
            if (!ModelState.IsValid || _context.Diagnosis == null || Diagnosis == null)
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
                var messageObject = new { message = Diagnosis.Message };
                var jsonContent = JsonConvert.SerializeObject(messageObject);
                var stringContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                // Send POST request to the API
                var response = await _httpClient.PostAsync("http://127.0.0.1:5000/chat", stringContent);

                // Check if the API call was successful
                if (response.IsSuccessStatusCode)
                {
                    // Read response content as string
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    // Parse the JSON response to extract the value of the "response" property
                    var jsonResponse = JObject.Parse(apiResponse);
                    var apiResponseValue = jsonResponse["response"]?.ToString();

                    Diagnosis.Response = apiResponseValue;
                    Diagnosis.UserID = userId;
                    _context.Diagnosis.Add(Diagnosis);
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
