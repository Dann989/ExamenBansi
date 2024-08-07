using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MX.BANSI.CORE.DLL.DOMAIN.Entities;

namespace MX.BANSI.BLAZOR.WEB.ExamenBansi.Pages
{
    public class CreateExamenModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public CreateExamenModel(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("https://localhost:7204");
            _httpClient = httpClient;
        }

        [BindProperty]
        public Examen Examen { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var response = await _httpClient.PostAsJsonAsync("/api/examenes", Examen);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("/Index");
            }

            ModelState.AddModelError(string.Empty, "Error creating examen.");
            return Page();
        }
    }
}
