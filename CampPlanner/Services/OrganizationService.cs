using CampPlanner.Models;
using System.Net.Http.Json;

namespace CampPlanner.Services
{
    public class OrganizationService
    {
        private readonly HttpClient _httpClient;

        public OrganizationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Organization>> GetOrganizationsAsync()
        {
            var organizations = await _httpClient.GetFromJsonAsync<List<Organization>>("api/organizations");
            return organizations ?? new List<Organization>();
        }

        public async Task<Organization> GetOrganizationByIdAsync(int id)
        {
            var organization = await _httpClient.GetFromJsonAsync<Organization>($"api/organizations/{id}");
            return organization ?? new Organization { Name = string.Empty };
        }

        public async Task CreateOrganizationAsync(Organization organization)
        {
            await _httpClient.PostAsJsonAsync("api/organizations", organization);
        }

        public async Task UpdateOrganizationAsync(Organization organization)
        {
            await _httpClient.PutAsJsonAsync($"api/organizations/{organization.Id}", organization);
        }

        public async Task DeleteOrganizationAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/organizations/{id}");
        }
    }
}