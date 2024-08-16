
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PredictionService
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseAddress;

        public ApiService(string baseAddress)
        {
            _baseAddress = baseAddress;
            _httpClient = new HttpClient();
        }

        // Study session functions

        public async Task<List<StudySessionModel>> GetSessionsAsync()
        {
            var response = await _httpClient.GetAsync($"{_baseAddress}/StudySession");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<StudySessionModel>>(responseBody);
        }

        // Progress functions
        public async Task<List<ProgressModel>> GetProgressesAsync()
        {
            var response = await _httpClient.GetAsync($"{_baseAddress}/Progress");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ProgressModel>>(responseBody);
        }
    }
}
