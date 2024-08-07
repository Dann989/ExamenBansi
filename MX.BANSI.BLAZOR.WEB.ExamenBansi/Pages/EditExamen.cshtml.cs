using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MX.BANSI.CORE.DLL.DOMAIN.Entities;

namespace MX.BANSI.BLAZOR.WEB.ExamenBansi.Pages
{
    public class EditExamenModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public EditExamenModel(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("https://localhost:7204");
            _httpClient = httpClient;
        }

        [BindProperty]
        public Examen Examen { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Examen = await _httpClient.GetFromJsonAsync<Examen>($"/api/examenes/{id}");

            if (Examen == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var response = await _httpClient.PutAsJsonAsync($"/api/examenes/{Examen.Id}", Examen);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("/Index");
            }

            ModelState.AddModelError(string.Empty, "Error updating examen.");
            return Page();
        }
    }
}
