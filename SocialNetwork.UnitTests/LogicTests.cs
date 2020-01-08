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
        private readonly IFriendRequestLogic friendRequestLogic;

        public LogicTests()
        {
            postLogic = new PostLogic(new PostRepository(new PostContext(new Connection(@"Data Source=mssql.fhict.local;Initial Catalog=dbi404906_ocial;User ID=dbi404906_ocial;Password=123"))));
            userLogic = new UserLogic(new UserRepository(new UserContext(new Connection(@"Data Source=mssql.fhict.local;Initial Catalog=dbi404906_ocial;User ID=dbi404906_ocial;Password=123"))));
            friendRequestLogic = new FriendRequestLogic(new FriendRequestRepository(new FriendRequestContext(new Connection(@"Data Source=mssql.fhict.local;Initial Catalog=dbi404906_ocial;User ID=dbi404906_ocial;Password=123"))));
        }

        private readonly User user1 = new User()
        {
            Username = "UnitTest1",
            Firstname = "JanUnitTest",
            Middlename = null,
            Lastname = "Jansen",
            Password = "123",
            Biography = "Test test test test test",
            City = "Test",
            Country = "Test",
            Birthdate = new DateTime(1941, 11, 29),
        };

        private readonly User user2 = new User()
        {
            Username = "UnitTest2",
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
            bool succesfull;
            try
            {
                //Act
                succesfull = userLogic.RegisterUser(user1);
            }
            finally
            {
                //Delete
                userLogic.DeleteUserAfterUnitTest(user1.Username);
            }            
            //Assert
            Assert.True(succesfull);
        }

        [Fact]
        public void GetUserDetails_Succes()
        {
            //Arrange
            user1.Id = userLogic.GetSessionId(user1).Id;
            User userDetails = new User();

            //Act
            userDetails = userLogic.GetUserDetails(user1);

            //Assert
            Assert.Equal("UnitTest1", user1.Username);
        }

        [Fact]
        public void DoesUsernameExist_True()
        {
            //Arange
            userLogic.RegisterUser(user1);
            bool DoesExist;            
            try
            {
                //Act
                DoesExist = userLogic.DoesUsernameExist(user1);
            }
            finally
            {
                //Delete
                userLogic.DeleteUserAfterUnitTest(user1.Username);
            }           
            //Assert 
            Assert.True(DoesExist);
        }

        [Fact]
        public void DoesUsernameExist_False()
        {
            //Arange
            bool DoesExist;

            //Act
            DoesExist = userLogic.DoesUsernameExist(user1);

            //Assert 
            Assert.False(DoesExist);
        }

        [Fact]
        public void EditProfileDetails_Succes()
        {
            //Arrange
            userLogic.RegisterUser(user1);
            user1.Id = userLogic.GetSessionId(user1).Id;
            bool succesfull;
            try
            {
                //Act
                succesfull = userLogic.EditProfileDetails(user1);
            }
            finally
            {
                //Delete
                userLogic.DeleteUserAfterUnitTest(user1.Username);
            }
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
            userLogic.RegisterUser(user1);
            try
            {
                //Act
                DoesMatch = userLogic.DoesUserCombinationMatch(user1);
            }
            finally
            {
                //Delete
                userLogic.DeleteUserAfterUnitTest(user1.Username);
            }
            //Assert
            Assert.True(DoesMatch);
        }

        [Fact]
        public void UsernamePasswordCombo_False()
        {
            //Arange
            bool DoesMatch;
            userLogic.RegisterUser(user1);
            user1.Password = "1234";
            try
            {
                //Act
                DoesMatch = userLogic.DoesUserCombinationMatch(user1);
            }
            finally
            {
                //Delete
                userLogic.DeleteUserAfterUnitTest(user1.Username);
            }
            //Assert
            Assert.False(DoesMatch);
        }

        [Fact]
        public void SearchUser_Succes()
        {
            //Arange
            userLogic.RegisterUser(user1);
            List<User> list = new List<User>();
            try
            {
                //Act
                list.AddRange(userLogic.GetSearchResult(user1.Firstname));
            }
            finally
            {
                //Delete
                userLogic.DeleteUserAfterUnitTest(user1.Username);
            }
            //Assert
            Assert.Single(list);
        }

        [Fact]
        public void SearchUser_Empty()
        {
            //Arange
            List<User> list = new List<User>();

            //Act
            list.AddRange(userLogic.GetSearchResult(user1.Firstname));

            //Assert
            Assert.Empty(list);
        }

        [Fact]
        public void SendFriendRequest_Succes()
        {
            //Arange
            bool succesfull;
            userLogic.RegisterUser(user1);
            userLogic.RegisterUser(user2);
            user1.Id = userLogic.GetSessionId(user1).Id;
            user2.Id = userLogic.GetSessionId(user2).Id;
            FriendRequest friendRequest = new FriendRequest()
            {
                SenderId = user1.Id,
                RecieverId = user2.Id,
                Recieved = DateTime.Now,
            };
            try
            {
                //Act
                succesfull = friendRequestLogic.SendFriendRequest(friendRequest);
            }
            finally
            {
                //Delete
                userLogic.DeleteUserAfterUnitTest(user1.Username);
                userLogic.DeleteUserAfterUnitTest(user2.Username);
            }

            //Assert
            Assert.True(succesfull);
        }

        [Fact]
        public void SendFriendRequestToYourself()
        {
            //Arange
            bool succesfull;
            userLogic.RegisterUser(user1);
            user1.Id = userLogic.GetSessionId(user1).Id;
            FriendRequest friendRequest = new FriendRequest()
            {
                //Both userId's are the same
                SenderId = user1.Id,
                RecieverId = user1.Id, 
                Recieved = DateTime.Now,
            };
            try
            {
                //Act
                succesfull = friendRequestLogic.SendFriendRequest(friendRequest);
            }
            finally
            {
                //Delete
                userLogic.DeleteUserAfterUnitTest(user1.Username);
                userLogic.DeleteUserAfterUnitTest(user2.Username);
            }

            //Assert
            Assert.False(succesfull);
        }

        [Fact]
        public void SendDublicateFriendRequest()
        {
            //Arange
            bool succesfull;
            userLogic.RegisterUser(user1);
            userLogic.RegisterUser(user2);
            user1.Id = userLogic.GetSessionId(user1).Id;
            user2.Id = userLogic.GetSessionId(user2).Id;
            FriendRequest friendRequest = new FriendRequest()
            {
                SenderId = user1.Id,
                RecieverId = user2.Id,
                Recieved = DateTime.Now,
            };
            try
            {
                //Act
                friendRequestLogic.SendFriendRequest(friendRequest);
                succesfull = friendRequestLogic.SendFriendRequest(friendRequest); //Dublicate Request
            }
            finally
            {
                //Delete
                userLogic.DeleteUserAfterUnitTest(user1.Username);
                userLogic.DeleteUserAfterUnitTest(user2.Username);
            }

            //Assert
            Assert.False(succesfull);
        }
    }
}