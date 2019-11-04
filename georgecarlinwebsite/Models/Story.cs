using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace georgecarlinwebsite.Models
{
    public class Story
    {
        private List<User> users = new List<User>();
        private List<Comment> comments = new List<Comment>();
        
        public string UserStory { get; set; }
        public string Title { get; set; }

        public List<User> Users { get { return users; } }

        public List<Comment> Comments { get { return comments; } }
    }
}
