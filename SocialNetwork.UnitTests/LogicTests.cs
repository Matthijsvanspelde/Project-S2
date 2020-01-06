using SocialNetwork.DAL.App_data;
using SocialNetwork.DAL.Contexts;
using SocialNetwork.DAL.Repositories;
using SocialNetwork.Logic;
using SocialNetwork.Logic.ILogic;
using SocialNetwork.Models;
using System;
using System.Collections.Generic;
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
            Firstname = "JanUnitTest",
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
        public void DoesUsernameExist_True()
        {
            //Arange
            userLogic.RegisterUser(user);
            bool DoesExist;

            //Act
            DoesExist = userLogic.DoesUsernameExist(user);

            //Delete
            userLogic.DeleteUserAfterUnitTest(user.Username);

            //Assert 
            Assert.True(DoesExist);
        }

        [Fact]
        public void DoesUsernameExist_False()
        {
            //Arange
            bool DoesExist;

            //Act
            DoesExist = userLogic.DoesUsernameExist(user);

            //Assert 
            Assert.False(DoesExist);
        }

        [Fact]
        public void EditProfileDetails_Succes()
        {
            //Arrange
            userLogic.RegisterUser(user);
            user.Id = userLogic.GetSessionId(user).Id;

            //Act
            bool succesfull = userLogic.EditProfileDetails(user);

            //Delete
            userLogic.DeleteUserAfterUnitTest(user.Username);

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

            //Assert
            Assert.False(succesfull);
        }

        [Fact]
        public void UsernamePasswordCombo_True()
        {
            //Arange
            bool DoesMatch;
            userLogic.RegisterUser(user);

            //Act
            DoesMatch = userLogic.DoesUserCombinationMatch(user);

            //Delete
            userLogic.DeleteUserAfterUnitTest(user.Username);

            //Assert
            Assert.True(DoesMatch);
        }

        [Fact]
        public void UsernamePasswordCombo_False()
        {
            //Arange
            bool DoesMatch;
            userLogic.RegisterUser(user);
            user.Password = "1234";

            //Act
            DoesMatch = userLogic.DoesUserCombinationMatch(user);

            //Delete
            userLogic.DeleteUserAfterUnitTest(user.Username);

            //Assert
            Assert.False(DoesMatch);
        }

        [Fact]
        public void SearchUser_Succes()
        {
            //Arange
            userLogic.RegisterUser(user);
            List<User> list = new List<User>();

            //Act
            list.AddRange(userLogic.GetSearchResult(user.Firstname));

            //Delete
            userLogic.DeleteUserAfterUnitTest(user.Username);

            //Assert
            Assert.Single(list);
        }

        [Fact]
        public void SearchUser_Empty()
        {
            //Arange
            List<User> list = new List<User>();

            //Act
            list.AddRange(userLogic.GetSearchResult(user.Firstname));

            //Assert
            Assert.Empty(list);
        }
    }
}