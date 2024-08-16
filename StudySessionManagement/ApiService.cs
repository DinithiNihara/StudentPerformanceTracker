using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StudySessionManagement;

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
        return JsonConvert.DeserializeObject<List<StudySessionModel>>(responseBody);
    }

    public async Task<StudySessionModel> GetSessionByIdAsync(int id)
    {
        var response = await _httpClient.GetAsync($"{_baseAddress}/StudySession/{id}");
        response.EnsureSuccessStatusCode();
        var responseBody = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<StudySessionModel>(responseBody);
    }

    public async Task<List<StudySessionModel>> GetSessionsByStudentIdAsync(int studentId)
    {
        var response = await _httpClient.GetAsync($"{_baseAddress}/StudySession/Student/{studentId}");
        response.EnsureSuccessStatusCode();
        var responseBody = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<StudySessionModel>>(responseBody);
    }

    public async Task CreateSessionAsync(StudySessionModel session)
    {
        var json = JsonConvert.SerializeObject(session);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync($"{_baseAddress}/StudySession", content);
        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateSessionAsync(int id, StudySessionModel session)
    {
        var json = JsonConvert.SerializeObject(session);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PutAsync($"{_baseAddress}/StudySession/{id}", content);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteSessionAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"{_baseAddress}/StudySession/{id}");
        response.EnsureSuccessStatusCode();
    }

    // Break functions
    public async Task<List<BreakModel>> GetBreaksAsync()
    {
        var response = await _httpClient.GetAsync($"{_baseAddress}/Break");
        response.EnsureSuccessStatusCode();
        var responseBody = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<BreakModel>>(responseBody);
    }

    public async Task<BreakModel> GetBreakByIdAsync(int id)
    {
        var response = await _httpClient.GetAsync($"{_baseAddress}/Break/{id}");
        response.EnsureSuccessStatusCode();
        var responseBody = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<BreakModel>(responseBody);
    }

    public async Task<List<BreakModel>> GetBreaksByStudySessionIdAsync(int id)
    {
        var response = await _httpClient.GetAsync($"{_baseAddress}/Break/Session/{id}");
        response.EnsureSuccessStatusCode();
        var responseBody = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<BreakModel>>(responseBody);
    }

    public async Task CreateBreakAsync(BreakModel breakModel)
    {
        var json = JsonConvert.SerializeObject(breakModel);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync($"{_baseAddress}/Break", content);
        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateBreakAsync(int id, BreakModel breakModel)
    {
        var json = JsonConvert.SerializeObject(breakModel);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PutAsync($"{_baseAddress}/Break/{id}", content);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteBreakAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"{_baseAddress}/Break/{id}");
        response.EnsureSuccessStatusCode();
    }

    // Progress functions
    public async Task<List<ProgressModel>> GetProgressesAsync()
    {
        var response = await _httpClient.GetAsync($"{_baseAddress}/Progress");
        response.EnsureSuccessStatusCode();
        var responseBody = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<ProgressModel>>(responseBody);
    }

    public async Task<ProgressModel> GetProgressByIdAsync(int id)
    {
        var response = await _httpClient.GetAsync($"{_baseAddress}/Progress/{id}");
        response.EnsureSuccessStatusCode();
        var responseBody = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<ProgressModel>(responseBody);
    }

    public async Task<List<ProgressModel>> GetProgressesByStudySessionIdAsync(int id)
    {
        var response = await _httpClient.GetAsync($"{_baseAddress}/Progress/Session/{id}");
        response.EnsureSuccessStatusCode();
        var responseBody = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<ProgressModel>>(responseBody);
    }

    public async Task CreateProgressAsync(ProgressModel progressModel)
    {
        var json = JsonConvert.SerializeObject(progressModel);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync($"{_baseAddress}/Progress", content);
        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateProgressAsync(int id, ProgressModel progressModel)
    {
        var json = JsonConvert.SerializeObject(progressModel);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PutAsync($"{_baseAddress}/Progress/{id}", content);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteProgressAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"{_baseAddress}/Progress/{id}");
        response.EnsureSuccessStatusCode();
    }
}
