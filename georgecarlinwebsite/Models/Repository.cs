using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace georgecarlinwebsite.Models
{
    public class Repository : IRepository
    {
        private static List<Story> stories = new List<Story>();
        private static List<Book> books = new List<Book>();

        public List<Story> Stories { get { return stories; } }
        public List<Book> Books { get { return books; } }

        public Repository()
        {
            if (Stories.Count == 0)
            {
                AddTestData();
            }
        }

        public void AddStory(Story story)
        {
            stories.Add(story);
        }

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public Book GetBookByTitle(string title)
        {
            Book book = books.Find(b => b.Title == title);
            return book;
        }

        public Story GetStoryByTitle(string title)
        {
            Story story = stories.Find(s => s.Title == title);
            return story;
        }

        void AddTestData()
        {
            Story story1 = new Story()
            {
                Title = "Awesome dude",
                UserStory = "He was Cool"
            };
            story1.Users.Add(new User
            {
                Name = "James Madison"
            }
            );
            AddStory(story1);

            Story story2 = new Story()
            {
                Title = "BAD ACT",
                UserStory = "He was horrible. I wouldn't recommend seeing him"
            };
            story2.Users.Add(new User
            {
                Name = "Carol Gale"
            });
            AddStory(story2);

            Story story3 = new Story()
            {
                Title = "CAN'T STOP LOVING HIS ACT",
                UserStory = "He was AWESOME. I would recommend seeing him"
            };
            story3.Users.Add(new User
            {
                Name = "Jim Farley"
            });
            AddStory(story3);

            if (Books.Count == 0)
            {
                Book book1 = new Book()
                {
                    Title = "Brain Droppings",
                    PubDate = new DateTime(1997, 5, 17)
                };
                book1.Authors.Add(new Author
                {
                    Name = "George Carlin"
                });
                Books.Add(book1);

                Book book2 = new Book()
                {
                    Title = "Last Words",
                    PubDate = new DateTime(2009, 11, 10)
                };
                book2.Authors.Add(new Author
                {
                    Name = "George Carlin"
                });
                Books.Add(book2);

                Book book3 = new Book()
                {
                    Title = "When Will Jesus Bring the Pork Chops?",
                    PubDate = new DateTime(2004, 10, 1)
                };
                book3.Authors.Add(new Author
                {
                    Name = "George Carlin"
                });
                Books.Add(book3);
            }
        }
    }
}
