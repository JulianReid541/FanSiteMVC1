using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace georgecarlinwebsite.Models
{
    public class User
    {       
        private List<Comment> comments = new List<Comment>();

        public int UserID { get; set; }
        public string Name { get; set; }       
        public List<Comment> Comments { get { return comments; } }
    }
}
