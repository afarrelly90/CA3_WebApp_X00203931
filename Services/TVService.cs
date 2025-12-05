using CA3_WebApp.Models;
using System.Net.Http.Json;

namespace CA3_WebApp.Services
{
    public class TVService
    {
        private readonly HttpClient _http;

        public TVService(HttpClient http)
        {
            _http = http;
            _http.BaseAddress = new Uri("https://api.tvmaze.com/");
        }
        public async Task<List<SearchResult>?> SearchShowsAsync(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return null;

            return await _http.GetFromJsonAsync<List<SearchResult>>($"search/shows?q={query}");
        }

        public async Task<Show?> GetShowAsync(int id)
        {
            if (id <= 0) return null;
            return await _http.GetFromJsonAsync<Show>($"shows/{id}");
        }
    }
}
