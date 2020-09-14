using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using practiceTest.Core;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.WebUtilities;

namespace practiceTest.Service
{
    public class AlbumService : IAlbumService
    {
        HttpClient httpClient;

        public AlbumService()
        {
            httpClient = new HttpClient();
        }

        public async Task<List<Album>> GetAlbumByIdAsync(int id)
        {
            List<Album> albums = new List<Album>();
            var query = new Dictionary<string, string>();
            query.Add("userId", id.ToString());

            using (var response = await httpClient.GetAsync(QueryHelpers.AddQueryString("https://jsonplaceholder.typicode.com/albums/", query)))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                albums = JsonConvert.DeserializeObject<List<Album>>(apiResponse);
            }

            return albums;
        }

        public async Task<Album> updateTitle(Album toUpdate)
        {
            StringBuilder uri = new StringBuilder();
            uri.Append("https://jsonplaceholder.typicode.com/albums/");
            uri.Append(toUpdate.id.ToString());

            Album updatedAlbum;

            var jsonRequest = JsonConvert.SerializeObject(toUpdate);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            using (var response = await httpClient.PatchAsync(uri.ToString(), content))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                updatedAlbum = JsonConvert.DeserializeObject<Album>(apiResponse);
            }

            return updatedAlbum;

        }

    }
}
