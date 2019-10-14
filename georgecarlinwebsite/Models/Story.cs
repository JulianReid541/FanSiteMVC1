using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace georgecarlinwebsite.Models
{
    public class Story
    {
        private List<User> users = new List<User>();
        
        public string UserStory { get; set; }

        public List<User> Users { get { return users; } }
    }
}
