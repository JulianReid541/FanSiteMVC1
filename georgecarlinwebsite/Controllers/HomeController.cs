using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using georgecarlinwebsite.Models;

namespace georgecarlinwebsite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult History()
        {
            return View();
        }

        [HttpGet]
        public ViewResult Stories()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Stories(Story s)
        {
            Repository.AddStory(s);
            return View();
        }

        public IActionResult InfoOne()
        {
            return View();
        }

        public IActionResult InfoTwo()
        {
            return View();
        }

        public ViewResult StoryList()
        {
            return View(Repository.Stories);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
