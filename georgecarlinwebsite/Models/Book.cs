using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace georgecarlinwebsite.Models
{
    public class Book
    {
        public int BookID { get; set; }
        private List<Author> authors = new List<Author>();

        public string Title { get; set; }
        public DateTime PubDate { get; set; }

        public List<Author> Authors { get { return authors; } }
    }
}
