using System.Net.Http.Json;
using CA3_WebApp.Models;

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
    }
}
