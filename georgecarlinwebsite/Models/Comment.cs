﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace georgecarlinwebsite.Models
{      
    public class Comment
    {      
        public int CommentID { get; set; }
        public string CommentText { get; set; }
        public User Commenter { get; set; }          
    }    
}
