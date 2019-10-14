using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace georgecarlinwebsite.Models
{
    public class Repository
    {
        private static List<Story> stories = new List<Story>();

        public static IEnumerable<Story> Stories
        {
            get
            {
                return stories;
            }
        }

        public static void AddStory(Story story)
        {
            stories.Add(story);
        }
    }
}
