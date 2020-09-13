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
    public class PhotoService : IPhotoService
    {
        public PhotoService()
        {

        }

        public async Task<int> GetAlbumByIdAsync(int id)
        {
            List<Album> albums = new List<Album>();
            var query = new Dictionary<string, string>();
            query.Add("userId", id.ToString());
            int idFirstAlbum = 0;

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(QueryHelpers.AddQueryString("https://jsonplaceholder.typicode.com/albums/", query)))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    albums = JsonConvert.DeserializeObject<List<Album>>(apiResponse);
                }
            }

            idFirstAlbum = albums[0].id;

            return idFirstAlbum;
        }

        public async Task<string> GetFirstThumbnail(int id)
        {
            StringBuilder uri = new StringBuilder();
            uri.Append("https://jsonplaceholder.typicode.com/albums/");
            uri.Append(id.ToString());
            uri.Append("/photos/");

            List<Photo> photos = new List<Photo>();
            string urlThumbnail = "";

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(uri.ToString()))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    photos = JsonConvert.DeserializeObject<List<Photo>>(apiResponse);
                }
            }

            urlThumbnail = photos[0].thumbnailUrl;

            return urlThumbnail;
        }
    }
}
