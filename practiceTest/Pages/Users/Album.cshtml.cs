using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using practiceTest.Core;
using practiceTest.Service;

namespace practiceTest.Pages.Users
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class HomeModel :Controller
    {

        private readonly IPhotoService photoService;
        private readonly IAlbumService albumService;

        public HomeModel( IPhotoService photoService, IAlbumService albumService)
        {
            this.photoService = photoService;
            this.albumService = albumService;
        }


        [HttpPost]
        public async Task<JsonResult> getAllPhotos([FromBody] Album search)
        {
            var albums = await photoService.GetAllPhotosInlbum(search.id);

            return Json(albums);
        }

        [HttpPost]
        [Route("create/")]
        public async Task<JsonResult> createPhoto([FromBody] Photo newPhoto)
        {
            var photoCreate = await photoService.addPhoto(newPhoto);

            return Json(photoCreate);
        }



        [HttpDelete]
        public async Task<JsonResult> deletePhoto([FromBody] Photo delete)
        {
            var albums = await photoService.DeletePhoto(delete.id);

            return Json(albums);
        }

    }
}