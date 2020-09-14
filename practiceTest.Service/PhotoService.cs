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

        HttpClient httpClient;

        public PhotoService()
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

        public async Task<string> GetFirstThumbnail(int id)
        {
            StringBuilder uri = new StringBuilder();
            uri.Append("https://jsonplaceholder.typicode.com/albums/");
            uri.Append(id.ToString());
            uri.Append("/photos/");

            List<Photo> photos = new List<Photo>();
            string urlThumbnail = "";

           
                using (var response = await httpClient.GetAsync(uri.ToString()))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    photos = JsonConvert.DeserializeObject<List<Photo>>(apiResponse);
                }
            

            urlThumbnail = photos[0].thumbnailUrl;

            return urlThumbnail;
        }

        public async Task<List<Photo>> GetAllPhotosInlbum(int albumId)
        {
            StringBuilder uri = new StringBuilder();
            uri.Append("https://jsonplaceholder.typicode.com/albums/");
            uri.Append(albumId.ToString());
            uri.Append("/photos/");

            List<Photo> photos = new List<Photo>();

           
                using (var response = await httpClient.GetAsync(uri.ToString()))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    photos = JsonConvert.DeserializeObject<List<Photo>>(apiResponse);
                }
            

            return photos;

        }

        public async Task<bool> DeletePhoto(int photoId)
        {

            StringBuilder uri = new StringBuilder();
            uri.Append("https://jsonplaceholder.typicode.com/photos/");
            uri.Append(photoId.ToString());

            bool isDeleted = false;

            
                using (var response = await httpClient.DeleteAsync(uri.ToString()))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var status = response.StatusCode;
                    if (status.ToString().Equals("OK"))
                    {
                        isDeleted = true;
                    }
                    
                }
            

            return isDeleted;

        }

        public async Task<Album> updateTitle(Album toUpdate)
        {
            StringBuilder uri = new StringBuilder();
            uri.Append("https://jsonplaceholder.typicode.com/albums/");
            uri.Append(toUpdate.id.ToString());

            Album updatedAlbum;

            var jsonRequest = JsonConvert.SerializeObject(toUpdate);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                using (var response = await httpClient.PatchAsync(uri.ToString(),content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    updatedAlbum = JsonConvert.DeserializeObject<Album>(apiResponse);
                }

            return updatedAlbum;
            
        }

        public async Task<Photo> addPhoto(Photo photo)
        {
            StringBuilder uri = new StringBuilder();
            uri.Append("https://jsonplaceholder.typicode.com/photos/");

            Photo createdPhoto;

            var jsonRequest = JsonConvert.SerializeObject(photo);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            using (var response = await httpClient.PostAsync(uri.ToString(), content))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                createdPhoto = JsonConvert.DeserializeObject<Photo>(apiResponse);
            }

            return createdPhoto;
        }

    }
}
