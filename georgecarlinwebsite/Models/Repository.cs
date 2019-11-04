using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace georgecarlinwebsite.Models
{
    public static class Repository
    {
        private static List<Story> stories = new List<Story>();
        private static List<Book> books = new List<Book>();

        public static List<Story> Stories { get { return stories; } }
        public static List<Book> Books { get { return books; } }

        public static void AddStory(Story story)
        {
            stories.Add(story);
        }

        public static void AddBook(Book book)
        {
            books.Add(book);
        }

        public static Book GetBookByTitle(string title)
        {
            Book book = books.Find(b => b.Title == title);
            return book;
        }

        public static Story GetStoryByTitle(string title)
        {
            Story story = stories.Find(s => s.Title == title);
            return story;
        }
    }
}
