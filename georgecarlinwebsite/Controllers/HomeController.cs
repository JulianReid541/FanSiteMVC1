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
        Story story1;
        Story story2;
        Story story3;
        Book book1;
        Book book2;
        Book book3;
        
        public HomeController()
        {
            if (Repository.Stories.Count == 0)
            {
                story1 = new Story()
                {
                    Title = "Awesome dude",
                    UserStory = "He was Cool"
                };
                story1.Users.Add(new User
                {
                    Name = "James Madison"
                }
                );
                Repository.AddStory(story1);

                story2 = new Story()
                {
                    Title = "BAD ACT",
                    UserStory = "He was horrible. I wouldn't recommend seeing him"
                };
                story2.Users.Add(new User
                {
                    Name = "Carol Gale"
                });
                Repository.AddStory(story2);

                story3 = new Story()
                {
                    Title = "CAN'T STOP LOVING HIS ACT",
                    UserStory = "He was AWESOME. I would recommend seeing him"
                };
                story3.Users.Add(new User
                {
                    Name = "Jim Farley"
                });
                Repository.AddStory(story3);
            }

            if (Repository.Books.Count == 0)
            {
                book1 = new Book()
                {
                    Title = "Brain Droppings",
                    PubDate = new DateTime(1997, 5, 17)
                };
                book1.Authors.Add(new Author
                {
                    Name = "George Carlin"
                });
                Repository.Books.Add(book1);

                book2 = new Book()
                {
                    Title = "Last Words",
                    PubDate = new DateTime(2009, 11, 10)
                };
                book2.Authors.Add(new Author
                {
                    Name = "George Carlin"
                });
                Repository.Books.Add(book2);

                book3 = new Book()
                {
                    Title = "When Will Jesus Bring the Pork Chops?",
                    PubDate = new DateTime(2004, 10, 1)
                };
                book3.Authors.Add(new Author
                {
                    Name = "George Carlin"
                });
                Repository.Books.Add(book3);
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

        public IActionResult Sources()
        {
            return View();
        }

        [HttpGet]
        public ViewResult Stories()
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
