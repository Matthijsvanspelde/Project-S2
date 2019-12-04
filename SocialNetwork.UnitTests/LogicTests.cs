using SocialNetwork.DAL.App_data;
using SocialNetwork.DAL.Contexts;
using SocialNetwork.DAL.Repositories;
using SocialNetwork.Logic;
using SocialNetwork.Logic.ILogic;
using SocialNetwork.Models;
using System;
using Xunit;

namespace SocialNetwork.UnitTests
{
    public class LogicTests
    {
        private readonly IUserLogic userLogic;
        private readonly IPostLogic postLogic;

        public LogicTests()
        {
            postLogic = new PostLogic(new PostRepository(new PostContext(new Connection(@"Data Source=mssql.fhict.local;Initial Catalog=dbi404906_ocial;User ID=dbi404906_ocial;Password=123"))));
            userLogic = new UserLogic(new UserRepository(new UserContext(new Connection(@"Data Source=mssql.fhict.local;Initial Catalog=dbi404906_ocial;User ID=dbi404906_ocial;Password=123"))));
        }

        private readonly User user = new User()
        {
            Username = "UnitTest",
            Firstname = "Jan",
            Middlename = null,
            Lastname = "Jansen",
            Password = "123",
            Biography = "Test test test test test",
            City = "Test",
            Country = "Test",
            Birthdate = new DateTime(1941, 11, 29),
        };

        [Fact]
        public void AddUser_Failed()
        {
            //Arrange
            User nullUser = new User();

            //Act
            bool succesfull = userLogic.RegisterUser(nullUser);

            //Assert
            Assert.False(succesfull);
        }

        [Fact]
        public void AddUser_Succes()
        {   
            //Act
            bool succesfull = userLogic.RegisterUser(user);
            string username = user.Username;

            //Delete
            userLogic.DeleteUserAfterUnitTest(username);

            //Assert
            Assert.True(succesfull);
        }

        [Fact]
        public void GetUserDetails_Succes()
        {
            //Arrange
            user.Id = userLogic.GetSessionId(user).Id;
            User userDetails = new User();

            //Act
            userDetails = userLogic.GetUserDetails(user);

            //Assert
            Assert.Equal("UnitTest", user.Username);
        }

        [Fact]
        public void EditProfileDetails_Succes()
        {
            //Arrange
            userLogic.RegisterUser(user);
            user.Id = userLogic.GetSessionId(user).Id;

            //Act
            bool succesfull = userLogic.EditProfileDetails(user);
            string username = user.Username;

            //Delete
            userLogic.DeleteUserAfterUnitTest(username);

            //Assert
            Assert.True(succesfull);
        }

        [Fact]
        public void EditProfileDetails_Failed()
        {
            //Arrange
            User userDetails = new User();

            //Act
            bool succesfull = userLogic.EditProfileDetails(userDetails);
            string username = user.Username;

            //Assert
            Assert.False(succesfull);
        }        
    }
}