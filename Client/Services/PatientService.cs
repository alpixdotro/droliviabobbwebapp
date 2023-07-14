using BlazorApp.Shared.Data.Models;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using static System.Net.WebRequestMethods;

namespace BlazorApp.Client.Services
{
    public class PatientService
    {
        private readonly HttpClient _httpClient;

        public PatientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<PatientModel>> GetPatients()
        {
            var json = await _httpClient.GetStringAsync("data-api/rest/Patient");
            var responseList = JsonConvert.DeserializeObject<PatientResponse>(json).Value;
            return responseList;
        }


        public async Task<PatientModel> GetPatient(int id)
        {
            return await _httpClient.GetFromJsonAsync<PatientModel>($"data-api/rest/Patient/Id/{id}");
        }

        public async Task<PatientModel> AddPatient(PatientPostModel patient)
        {
            var payload = JsonConvert.SerializeObject(patient);
            var response = await _httpClient.PostAsync("data-api/rest/Patient", new StringContent(payload, Encoding.UTF8, "application/json"));

            if (!response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"AddPatient error: {response.StatusCode} - {responseContent}");
                // You can throw an exception or handle the error as needed
                throw new Exception($"AddPatient failed: {response.StatusCode} - {responseContent}");
            }

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

    public class PatientResponse
    {
        [JsonProperty("value")]
        public List<PatientModel> Value { get; set; }
    }
}
