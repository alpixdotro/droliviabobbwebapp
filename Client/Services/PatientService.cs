using BlazorApp.Shared.Data.Models;
using System.Net.Http.Json;

namespace BlazorApp.Client.Services
{
    public class PatientService
    {
        private readonly HttpClient _httpClient;

        public PatientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PatientModel[]> GetPatients()
        {
            return await _httpClient.GetFromJsonAsync<PatientModel[]>("api/patient");
        }

        public async Task<PatientModel> GetPatient(int id)
        {
            return await _httpClient.GetFromJsonAsync<PatientModel>($"api/patient/{id}");
        }

        public async Task<PatientModel> AddPatient(PatientModel patient)
        {
            var response = await _httpClient.PostAsJsonAsync("api/patient", patient);
            return await response.Content.ReadFromJsonAsync<PatientModel>();
        }

        public async Task UpdatePatient(PatientModel patient)
        {
            await _httpClient.PutAsJsonAsync($"api/patient/{patient.Id}", patient);
        }

        public async Task DeletePatient(int id)
        {
            await _httpClient.DeleteAsync($"api/patient/{id}");
        }

    }
}
