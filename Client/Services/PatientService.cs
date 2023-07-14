﻿using BlazorApp.Shared.Data.Models;
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
            return await _httpClient.GetFromJsonAsync<PatientModel[]>("data-api/rest/Patient");
        }

        public async Task<PatientModel> GetPatient(int id)
        {
            return await _httpClient.GetFromJsonAsync<PatientModel>($"data-api/rest/Patient/Id/{id}");
        }

        public async Task<PatientModel> AddPatient(PatientModel patient)
        {
            var response = await _httpClient.PostAsJsonAsync("data-api/rest/Patient/", patient);
            return await response.Content.ReadFromJsonAsync<PatientModel>();
        }

        public async Task UpdatePatient(PatientModel patient)
        {
            await _httpClient.PutAsJsonAsync($"data-api/rest/Patient/Id/{patient.Id}", patient);
        }

        public async Task DeletePatient(int id)
        {
            await _httpClient.DeleteAsync($"data-api/rest/Patient/Id/{id}");
        }

    }
}
