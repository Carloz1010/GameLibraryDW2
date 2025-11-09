
using System.Text.Json;

namespace GameLibrary.Frontend.Services
{
    public class GameService(HttpClient httpClient) : IGameService
    {
        private readonly HttpClient _httpClient = httpClient;

        private static JsonSerializerOptions JsonDefaultOptions => new()
        {
            PropertyNameCaseInsensitive = true
        };

        public async Task<T> GetAsync<T>(string url)
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(content, JsonDefaultOptions)!;
        }

        public async Task<T> GetByIdAsync<T>(string url, string SKU)
        {
            var requestUrl = $"{url}/{SKU}";
            var response = await _httpClient.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(content, JsonDefaultOptions)!;
        }

        public async Task<HttpResponseMessage> PostAsync<T>(string url, T model)
        {
            var content = new StringContent(JsonSerializer.Serialize(model), System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);
            return response;
        }
    }
}
