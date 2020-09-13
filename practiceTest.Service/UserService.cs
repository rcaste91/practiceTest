using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using practiceTest.Core;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.WebUtilities;

namespace practiceTest.Service
{
    public class ServiceConnect : IUserService
    {

        public ServiceConnect()
        {

        }

        public async Task<List<User>> GetAllUsers()
        {
            List<User> userList = new List<User>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/users/"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    userList = JsonConvert.DeserializeObject<List<User>>(apiResponse);
                }
            }

            
            return userList;
        }

        public async Task<List<User>> GetUserByNames(string name, string username, string email)
        {
            List<User> userList = new List<User>();
            var query = new Dictionary<string, string>();
            query = createSearch( name,  username,  email);

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(QueryHelpers.AddQueryString("https://jsonplaceholder.typicode.com/users/", query)))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    userList = JsonConvert.DeserializeObject<List<User>>(apiResponse);
                }
            }

            return userList;

        }

        public Dictionary<string,string> createSearch(string name, string username, string email)
        {
            Dictionary<string, string> filters = new Dictionary<string, string>();

            if (!string.IsNullOrEmpty(name))
            {
                filters.Add("name", name);
            }

            if (!string.IsNullOrEmpty(username))
            {
                filters.Add("username", username);
            }

            if (!string.IsNullOrEmpty(email))
            {
                filters.Add("email", email);
            }

            return filters;
        }

    }
}
