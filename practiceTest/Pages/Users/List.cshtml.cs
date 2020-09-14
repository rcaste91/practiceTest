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

        public ListModel(IUserService serviceConnect, IPhotoService photoService)
        {
            this._serviceConnect = serviceConnect;
            this.photoService = photoService;
        }

        public List<User> userList { get; set; }


        public async Task<IActionResult> OnGetAsync()
        {

            var userListi = await _serviceConnect.GetAllUsers();
            var f = _serviceConnect.GetDistinctCities();
            //var t = await _serviceConnect.GetUserByNames("", "", "Chaim_McDermott@dana.io");
            //var photoId = await photoService.GetAlbumByIdAsync(1);
            //var photoThu = await photoService.GetFirstThumbnail(1);
            //var photoThu = await photoService.GetAllPhotosInlbum(1);
            var photoThu = await photoService.DeletePhoto(1);

            userList = userListi;
            
            if (userList == null)
                return NotFound();


            return Page();
        }
    }
}