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
    public class ListModel  :Controller
    {

        private readonly IUserService serviceConnect;
        private readonly IPhotoService photoService;
        private readonly IAlbumService albumService;

        public List<User> userList { get; set; }
        public List<UserDisplay> displayList { get; set; }

        public ListModel(IUserService serviceConnect, IPhotoService photoService, IAlbumService albumService)
        {
            this.serviceConnect = serviceConnect;
            this.photoService = photoService;
            this.albumService = albumService;

            displayList = new List<UserDisplay>();
        }

        [HttpGet]
        public async Task<JsonResult> getUsers()
        {
            userList = await serviceConnect.GetAllUsers();
            
            UserDisplay us = new UserDisplay();

            foreach (User u in userList)
            {
                us.address = u.address;
                us.name = u.name;
                us.username = u.username;
                us.email = u.email;
                us.id = u.id;
                us.address = u.address;
                us.thumbnail = await photoService.GetFirstThumbnail(u.id);
                displayList.Add(us);
                us = new UserDisplay();
            }
            
            

            return Json(displayList);
        }

        [HttpPost]
        [Route("search/")]
        public async Task<JsonResult> search([FromBody] Search search)
        {

           userList = await serviceConnect.GetUserByNames(search.sName, search.sUsername, search.sEmail);

            UserDisplay us = new UserDisplay();

            foreach (User u in userList)
            {
                us.address = u.address;
                us.name = u.name;
                us.username = u.username;
                us.email = u.email;
                us.id = u.id;
                us.address = u.address;
                us.thumbnail = await photoService.GetFirstThumbnail(u.id);
                displayList.Add(us);
                us = new UserDisplay();
            }

            return Json(displayList);
        }

    

    }
}