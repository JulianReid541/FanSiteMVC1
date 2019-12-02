using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace georgecarlinwebsite.Models
{
    public interface IRepository
    {
        List<Story> Stories { get; }
        List<Book> Books { get; }
        void AddBook(Book book);
        void AddStory(Story story);
        void AddComment(Story story, Comment comment);
        Story GetStoryByTitle(string title);
        Book GetBookByTitle(string title);
    }
}
