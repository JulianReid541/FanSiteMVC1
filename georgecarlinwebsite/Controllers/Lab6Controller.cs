using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace georgecarlinwebsite.Controllers
{
    public class Lab6Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public ContentResult Content()
        {
            return Content("I AM FROM A RETURN OF CONTENT", "text/plain");
        }

        public RedirectResult Redirect()
        {
            return Redirect("https://www.twitch.tv/");
        }

        //Produces 400 Error
        public BadRequestResult BadRequestResult()
        {
            return BadRequest();
        }

        //Produces 200 OK
        public OkResult Result()
        {
            return new OkResult();
        }
    }
}