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
        Story story;    
        
        public HomeController()
        {
            if (Repository.Stories.Count == 0)
            {
                story = new Story()
                {
                    UserStory = "He was Cool"
                };
                story.Users.Add(new User
                {
                    Name = "James Madison"
                }
                );
                Repository.AddStory(story);
            }
        }
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
        public RedirectToActionResult Stories(string s, string name)
        {
            story = new Story();
            story.UserStory = s;
            story.Users.Add(new User() { Name = name });
            Repository.AddStory(story);
            return RedirectToAction("StoryList");
        }

        public IActionResult InfoOne()
        {
            return View();
        }

        public IActionResult InfoTwo()
        {
            return View();
        }

        public IActionResult AddComment(string title)
        {
            return View("AddComment", title);
        }

        [HttpPost]
        public RedirectToActionResult AddComment(string commenttext, string commenter)
        {
            story.Comments.Add(new Comment() {
                Commenter = new User() { Name = commenter },
                CommentText = commenttext });
            return RedirectToAction("StoryList");
        }

        public ViewResult StoryList()
        {
            List<Story> stories = Repository.Stories;
            return View(stories);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
