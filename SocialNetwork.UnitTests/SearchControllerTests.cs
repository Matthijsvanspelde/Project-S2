using Moq;
using SocialNetwork.Models;
using SocialNetwork.DAL;
using SocialNetwork.Logic;
using System.Collections.Generic;
using Xunit;
using SocialNetwork.DAL.IRepositories;
using SocialNetwork.Controllers;
using SocialNetwork.Logic.ILogic;

namespace SocialNetwork.UnitTests
{
    public class SearchControllerTests
    {
        [Fact]
        public void GetSearchUsers_Count()
        {
            
            string SearchTerm = "Peter";
            
            //Arrange
            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(repo => repo.GetSearchResult(SearchTerm))
                .Returns(TestUsersList());
            UserLogic userLogic = new UserLogic(mockRepo.Object);
            List<User> list = new List<User>();

            //Act
            list.AddRange(userLogic.GetSearchResult(SearchTerm));

            //Assert
            Assert.Equal(3, list.Count);
        }

        private IEnumerable<User> TestUsersList()
        {
            return new List<User>()
            {
                new User()
                {
                    Id = 1,
                    Firstname = "Peters"
                },
                new User()
                {
                    Id = 2,
                    Firstname = "peter"
                },
                new User()
                {
                    Id = 2,
                    Firstname = "jan"
                }
            };
        }

    }
}
