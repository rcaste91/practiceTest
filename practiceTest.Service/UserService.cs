using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using practiceTest.Core;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.WebUtilities;
using System.Linq;

namespace practiceTest.Service
{
    public class ServiceConnect : IUserService
    {

        public List<User> userList { get; set; }

        public ServiceConnect()
        {
            userList = new List<User>();
        }

        public async Task<List<User>> GetAllUsers()
        {
            //List<User> userList = new List<User>();
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
            List<User> users = new List<User>();
            
            var query = new Dictionary<string, string>();
            query = createSearch( name,  username,  email);

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(QueryHelpers.AddQueryString("https://jsonplaceholder.typicode.com/users/", query)))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    users = JsonConvert.DeserializeObject<List<User>>(apiResponse);
                }
            }

            return users;

        }

        public async Task<List<User>> GetUserByCity(string city)
        {
            List<User> users = await GetAllUsers();

            List<User> usersByCity = users.FindAll(s => s.address.city.Equals(city));

            return usersByCity;

        }

        public List<string> GetDistinctCities()
        {
            List<string> cities = new List<string>();

            foreach(var u in userList)
            {
                cities.Add(u.address.city);
            }
            
            List<string> distinctCities = cities.Distinct().ToList();

            return distinctCities;

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
