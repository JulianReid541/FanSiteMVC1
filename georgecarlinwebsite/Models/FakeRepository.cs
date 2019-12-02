using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace georgecarlinwebsite.Models
{
    public class FakeRepository : IRepository
    {
        private List<Story> stories = new List<Story>();
        private List<Book> books = new List<Book>();
        public List<Story> Stories { get { return stories; } }
        public List<Book> Books { get { return books; } }

        public void AddStory(Story story)
        {
            stories.Add(story);
        }

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public Story GetStoryByTitle(string title)
        {
            Story story = stories.Find(s => s.Title == title);
            return story;
        }

        public void AddComment(Story s, Comment c)
        {
            Story theStory = stories.First<Story>(story => story.StoryID == s.StoryID);
            theStory.Comments.Add(c);
        }

        public Book GetBookByTitle(string title)
        {
            Book book = books.Find(b => b.Title == title);
            return book;
        }
    }
}
