
using global::MX.BANSI.CORE.DLL.DOMAIN.Entities;

namespace MX.BANSI.BLAZOR.WEB.ExamenBansi.Services
{
    public class ExamenApiService
    {
        private readonly HttpClient _httpClient;

        public ExamenApiService(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("https://localhost:7204");
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Examen>> GetAllExamenesAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Examen>>("api/examenes"); // URI relativa
        }

        public async Task<Examen> GetExamenByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Examen>($"api/examenes/{id}"); // URI relativa
        }

        public async Task CreateExamenAsync(Examen examen)
        {
            var response = await _httpClient.PostAsJsonAsync("api/examenes", examen); // URI relativa
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateExamenAsync(Examen examen)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/examenes/{examen.Id}", examen); // URI relativa
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteExamenAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/examenes/{id}"); // URI relativa
            response.EnsureSuccessStatusCode();
        }
    }
}
