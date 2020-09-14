using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using practiceTest.Core;
using practiceTest.Service;

namespace practiceTest.Pages.Users
{
    public class ListModel : PageModel
    {

        private readonly IUserService _serviceConnect;
        private readonly IPhotoService photoService;
        private readonly IAlbumService albumService;

        public ListModel(IUserService serviceConnect, IPhotoService photoService, IAlbumService albumService)
        {
            this._serviceConnect = serviceConnect;
            this.photoService = photoService;
            this.albumService = albumService;
        }

        public List<User> userList { get; set; }


        public async Task<IActionResult> OnGetAsync()
        {

            var userListi = await _serviceConnect.GetAllUsers();
            var f = _serviceConnect.GetDistinctCities();
            //var t = await _serviceConnect.GetUserByNames("", "", "Chaim_McDermott@dana.io");
            var photoId = await albumService.GetAlbumByIdAsync(1);
            var photoThu = await photoService.GetFirstThumbnail(1);
            var photoThu2 = await photoService.GetAllPhotosInlbum(1);
            var photoThu3 = await photoService.DeletePhoto(1);
            //
            Album album = new Album();
            album.id = 1;
            album.userId = 1;
            album.title = "nuevo titulo de prueba";
            var ty = await albumService.updateTitle(album);
            //
            Photo newPhoto = new Photo();
            newPhoto.albumId = 1;
            newPhoto.id = 9999;
            newPhoto.title = "Ronald";
            newPhoto.url = "https://google.com";
            newPhoto.thumbnailUrl = "https://google.com";

            var yy = await photoService.addPhoto(newPhoto);

            userList = userListi;
            
            if (userList == null)
                return NotFound();


            return Page();
        }
    }
}