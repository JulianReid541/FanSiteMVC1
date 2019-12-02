using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using georgecarlinwebsite.Models;
using Microsoft.Extensions.DependencyInjection;

namespace georgecarlinwebsite.Models
{
    public class SeedData
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (!context.Stories.Any())
            {
                User user = new User { Name = "James Matthews" };
                context.Add(user);

                User commentUser = new User { Name = "Eric Thompson" };
                context.Add(commentUser);

                Story story = new Story
                {
                    Title = "HE WAS AMAZING",
                    UserStory = "I saw him yesterday",
                };

                Comment comment = new Comment()
                {
                    Commenter = commentUser,
                    CommentText = "I'm jealous man"
                };
                context.Comments.Add(comment);

                story.Users.Add(user);
                story.Comments.Add(comment);
                context.Stories.Add(story);

                context.SaveChanges();
            }
        }
    }
}
