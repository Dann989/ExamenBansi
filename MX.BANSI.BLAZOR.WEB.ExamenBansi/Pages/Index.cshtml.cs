using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MX.BANSI.CORE.DLL.DOMAIN.Entities;

namespace MX.BANSI.BLAZOR.WEB.ExamenBansi.Pages
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient _httpClient;


        public IndexModel(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("https://localhost:7204");
            _httpClient = httpClient;
        }

        public List<Examen> Examenes { get; set; }

        public async Task OnGetAsync()
        {
            Examenes = await _httpClient.GetFromJsonAsync<List<Examen>>("api/examenes");
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/examenes/{id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage();
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Error deleting examen.");
                return Page();
            }
        }
    }
}
