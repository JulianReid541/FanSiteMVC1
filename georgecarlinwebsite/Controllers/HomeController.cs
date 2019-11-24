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
        IRepository Repository;              
        public HomeController(IRepository r)
        {
            Repository = r;
        }
        public IActionResult Index()
        {
            ViewBag.welcome = "WELCOME";
            ViewData["Date"] = DateTime.Now.Date.ToString("MM-dd-yyyy");
            ViewData["Time"] = DateTime.Now.ToString("t");
            return View();
        }

        public IActionResult History()
        {
            return Content("This is content");
        }

        public IActionResult Sources()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Stories()
        {
            return View();
        }

        [HttpPost]
        public RedirectToActionResult Stories(string s, string name, string title)
        {
            Story story = new Story();
            story.Title = title;
            story.UserStory = s;
            story.Users.Add(new User() { Name = name });
            Repository.AddStory(story);
            return RedirectToAction("StoryList");
        }

        public IActionResult Books()
        {
            List<Book> books = Repository.Books;
            books.Sort((b1, b2) => string.Compare(b1.Title, b2.Title));
            ViewData["newestBook"] = books[books.Count - 1].Title;
            ViewBag.bookCount = books.Count;
            return View(books);
        }

        public IActionResult Links()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddComment(string title)
        {
            return View("AddComment", title);
        }

        [HttpPost]
        public RedirectToActionResult AddComment(string title, string commenttext, string commenter)
        {
            Story story = Repository.GetStoryByTitle(title);
            story.Comments.Add(new Comment() {
                Commenter = new User() { Name = commenter },
                CommentText = commenttext });
            return RedirectToAction("StoryList");
        }

        public IActionResult StoryList()
        {
            List<Story> stories = Repository.Stories;
            stories.Sort((s1, s2) => string.Compare(s1.Title, s2.Title));
            return View(stories);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
