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

        public LogicTests()
        {
            userLogic = new UserLogic(new UserRepository(new UserContext(new Connection(@"Data Source=mssql.fhict.local;Initial Catalog=dbi404906_ocial;User ID=dbi404906_ocial;Password=123"))));
        }

        private readonly User user = new User()
        {
            Username = "UnitTest",
            Firstname = "Jan",
            Middlename = null,
            Lastname = "Jansen",
            Password = "123",
            Birthdate = new DateTime(1941, 11, 29),
        };

        [Fact]
        public void AddUser_Failed()
        {
            User nullUser = new User();
            bool succesfull = userLogic.RegisterUser(nullUser);
            Assert.False(succesfull);
        }

        [Fact]
        public void AddUser_Succes()
        {
            bool succesfull = userLogic.RegisterUser(user);
            Assert.True(succesfull);
        }

        [Fact]
        public void GetUserDetails_Succes()
        {
            int Id = userLogic.GetSessionId(user).Id;
            user.Id = Id;
            User userDetails = new User();
            userDetails = userLogic.GetUserDetails(user);
            Assert.Equal("UnitTest", user.Username);
        }
    }
}
