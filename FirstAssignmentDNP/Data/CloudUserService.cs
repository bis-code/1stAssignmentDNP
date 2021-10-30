using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Models;

namespace FirstAssignmentDNP.Data
{
    public class CloudUserService : IUsersData
    {
        private string uri = "https://localhost:5003";

        private readonly HttpClient client;

        public CloudUserService()
        {
            client = new HttpClient();
        }

        public async Task<IList<User>> GetUsersAsync()
        {
            HttpResponseMessage response = await client.GetAsync(uri + "/users");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error");
            }

            string message = await response.Content.ReadAsStringAsync();
            List<User> result = JsonSerializer.Deserialize<List<User>>(message);
            return result;
        }

        public async Task AddUserAsync(User user)
        {
            string userAsJson = JsonSerializer.Serialize(user);
            HttpContent content = new StringContent(userAsJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync($"{uri}/users", content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error, {response.StatusCode}, {response.ReasonPhrase}");
            }
        }

        public async Task AddFamilyToUserAsync(Family family, int userId)
        {
            string familyAsJson = JsonSerializer.Serialize(family);
            HttpContent content = new StringContent(familyAsJson,
                Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PatchAsync($"{uri}/family/{family.Id}", content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error, {response.StatusCode}, {response.ReasonPhrase}");
            }
        }

        public async Task AddPersonToUserAsync(Person person, int userId)
        {
            string personAsJson = JsonSerializer.Serialize(person);
            HttpContent content = new StringContent(personAsJson,
                Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PatchAsync($"{uri}/person/{person.Id}", content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error, {response.StatusCode}, {response.ReasonPhrase}");
            }
        }

        public async Task<User> GetUserAsync(int userID)
        {
            HttpResponseMessage response = await client.GetAsync($"{uri}/users/{userID}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error");
            }

            string message = await response.Content.ReadAsStringAsync();
            User result = JsonSerializer.Deserialize<User>(message);
            return result;
        }

        public async Task<User> GetUserAsync(string username)
        {
            HttpResponseMessage response = await client.GetAsync($"{uri}/users/{username}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error");
            }

            string message = await response.Content.ReadAsStringAsync();
            User result = JsonSerializer.Deserialize<User>(message);
            return result;
        }

        public async Task UpdateAsync(User user)
        {
            string userAsJson = JsonSerializer.Serialize(user);
            HttpContent content = new StringContent(userAsJson,
                Encoding.UTF8,
                "application/json");
            HttpResponseMessage response = await client.PatchAsync($"{uri}/users/{user.Id}", content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error, {response.StatusCode}, {response.ReasonPhrase}");
            }
        }

        public async Task RemoveUserAsync(User user)
        {
            HttpResponseMessage response = await client.DeleteAsync($"{uri}/users/{user.Id}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error, {response.StatusCode}, {response.ReasonPhrase}");
            }
        }
    }
}