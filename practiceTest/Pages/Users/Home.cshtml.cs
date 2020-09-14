using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using practiceTest.Core;

namespace practiceTest.Pages.Users
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class HomeModel :Controller
    {

        public HomeModel()
        {

        }


        public string OnGet()
        {
            Album obj = new Album();
            obj.id = 1;
            obj.title = "Ronald";
            obj.userId = 2;
            return "Roanld";
        }
        
        

        [HttpGet]
        public JsonResult getStudents()
        {
            Album obj = new Album();
            obj.id = 1;
            obj.title = "Ronald";
            obj.userId = 2;

            var jr = JsonConvert.SerializeObject(obj);
            var r = new JsonResult(jr);
            //r.ContentType= "application / json";

            return Json(obj);
           
            
        }


    }
}