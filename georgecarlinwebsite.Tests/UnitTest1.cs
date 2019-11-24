using System;
using System.Collections.Generic;
using georgecarlinwebsite.Controllers;
using georgecarlinwebsite.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace georgecarlinwebsite.Tests
{
    public class RepositoryTest
    {
        [Fact]
        public void AddStoryTest()
        {
            //Arrange
            var repo = new FakeRepository();
            var homeController = new HomeController(repo);

            //Act
            homeController.Stories("He's awesome", "Jan", "Amazing");

            //Assert
            Assert.Equal("Amazing", repo.Stories[repo.Stories.Count - 1].Title);
        }

        [Fact]
        public void StoryListTest()
        {
            //Arrange
            var repo = new FakeRepository();
            AddTestData(repo);
            var homeController = new HomeController(repo);

            //Act
            var result = (ViewResult)homeController.StoryList();
            var stories = (List<Story>)result.Model;

            //Assert
            Assert.Equal(3, stories.Count);
            Assert.True(string.Compare(stories[0].Title, stories[1].Title) < 0 &&
                        string.Compare(stories[1].Title, stories[2].Title) < 0);
        }

        [Fact]
        public void AddCommentTest()
        {
            //Arrange
            var repo = new FakeRepository();
            AddTestData(repo);
            var homeController = new HomeController(repo);

            //Act
            homeController.AddComment("Awesome dude", "He was amazing", "Jan Arnold");

            //Assert
            Assert.Equal("He was amazing", repo.GetStoryByTitle("Awesome dude").Comments[0].CommentText);
            Assert.Equal("Jan Arnold", repo.GetStoryByTitle("Awesome dude").Comments[0].Commenter.Name);
        }

        private void AddTestData(FakeRepository repo)
        {
            Story story1 = new Story()
            {
                Title = "Awesome dude",
                UserStory = "He was Cool"
            };
            story1.Users.Add(new User
            {
                Name = "James Madison"
            }
            );
            repo.AddStory(story1);

            Story story2 = new Story()
            {
                Title = "BAD ACT",
                UserStory = "He was horrible. I wouldn't recommend seeing him"
            };
            story2.Users.Add(new User
            {
                Name = "Carol Gale"
            });
            repo.AddStory(story2);

            Story story3 = new Story()
            {
                Title = "CAN'T STOP LOVING HIS ACT",
                UserStory = "He was AWESOME. I would recommend seeing him"
            };
            story3.Users.Add(new User
            {
                Name = "Jim Farley"
            });
            repo.AddStory(story3);

            if (repo.Books.Count == 0)
            {
                Book book1 = new Book()
                {
                    Title = "Brain Droppings",
                    PubDate = new DateTime(1997, 5, 17)
                };
                book1.Authors.Add(new Author
                {
                    Name = "George Carlin"
                });
                repo.Books.Add(book1);

                Book book2 = new Book()
                {
                    Title = "Last Words",
                    PubDate = new DateTime(2009, 11, 10)
                };
                book2.Authors.Add(new Author
                {
                    Name = "George Carlin"
                });
                repo.Books.Add(book2);

                Book book3 = new Book()
                {
                    Title = "When Will Jesus Bring the Pork Chops?",
                    PubDate = new DateTime(2004, 10, 1)
                };
                book3.Authors.Add(new Author
                {
                    Name = "George Carlin"
                });
                repo.Books.Add(book3);
            }
        }
    }
}
