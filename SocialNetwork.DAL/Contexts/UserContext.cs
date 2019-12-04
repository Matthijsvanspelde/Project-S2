using Microsoft.Data.SqlClient;
using SocialNetwork.DAL.App_data;
using SocialNetwork.DAL.IContexts;
using SocialNetwork.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace SocialNetwork.DAL.Contexts
{
    public class UserContext : IUserContext
    {
        private readonly Connection _connection;

        public UserContext(Connection connection)
        {
            _connection = connection;
        }
       
        public bool RegisterUser(User user)
        {
            try
            {
                _connection.SqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("RegisterUser", _connection.SqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Username", user.Username);
                sqlCommand.Parameters.AddWithValue("@Password", user.Password);
                sqlCommand.Parameters.AddWithValue("@Firstname", user.Firstname);
                sqlCommand.Parameters.AddWithValue("@Middlename", user.Middlename);
                sqlCommand.Parameters.AddWithValue("@Lastname", user.Lastname);
                sqlCommand.Parameters.AddWithValue("@Birthdate", user.Birthdate);
                sqlCommand.Parameters.AddWithValue("@Country", "Unknown");
                sqlCommand.Parameters.AddWithValue("@City", "Unknown");
                sqlCommand.Parameters.AddWithValue("@Biography", "Nothing yet");
                sqlCommand.ExecuteNonQuery();
                _connection.SqlConnection.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw new Exception("Had trouble connecting with the server.");
            }            
        }

        public bool DoesUsernameExist(User user)
        {
            try
            {
                _connection.SqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("CheckDublicateUsername", _connection.SqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Username", user.Username);
                var returnParameter = sqlCommand.Parameters.Add("@Return", SqlDbType.Bit);
                returnParameter.Direction = ParameterDirection.ReturnValue;
                sqlCommand.ExecuteNonQuery();
                bool DoesExist = Convert.ToBoolean(returnParameter.Value);
                _connection.SqlConnection.Close();
                return DoesExist;
            }
            catch (Exception)
            {
                throw new Exception("Had trouble connecting with the server.");
            }
        }

        public bool DoesUserCombinationMatch(User user)
        {
            try
            {
                _connection.SqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("VerifyUser", _connection.SqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Username", user.Username);
                sqlCommand.Parameters.AddWithValue("@Password", user.Password);
                var returnParameter = sqlCommand.Parameters.Add("@Return", SqlDbType.Bit);
                returnParameter.Direction = ParameterDirection.ReturnValue;
                sqlCommand.ExecuteNonQuery();
                bool DoesMatch = Convert.ToBoolean(returnParameter.Value);
                _connection.SqlConnection.Close();
                return DoesMatch;
            }
            catch (Exception)
            {
                throw new Exception("Had trouble connecting with the server.");
            }
            
        }

        public User GetSessionId(User user)
        {
            try
            {
                _connection.SqlConnection.Open();
                SqlCommand sqlCmd = new SqlCommand("GetSessionId", _connection.SqlConnection);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Username", user.Username);
                sqlCmd.ExecuteNonQuery();
                using (SqlDataReader reader = sqlCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        user.Id = reader.GetInt32(0);
                    }
                }
                _connection.SqlConnection.Close();
                return user;
            }
            catch (Exception)
            {
                throw new Exception("Had trouble connecting with the server.");
            }           
        }
        
        public User GetUserDetails(User user)
        {
            try
            {
                _connection.SqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("GetUserDetails", _connection.SqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Id", user.Id);
                sqlCommand.ExecuteNonQuery();
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        user.Id = reader.GetInt32(0);
                        user.Firstname = reader.GetString(1);
                        user.Middlename = reader.GetString(2);
                        user.Lastname = reader.GetString(3);
                        user.Birthdate = reader.GetDateTime(4);
                        user.Country = reader.GetString(5);
                        user.City = reader.GetString(6);
                        user.Biography = reader.GetString(7);
                    }
                }
                _connection.SqlConnection.Close();
                return user;
            }
            catch (Exception)
            {
                throw new Exception("Had trouble connecting with the server.");
            }            
        }

        public bool EditProfileDetails(User user)
        {
            try
            {
                _connection.SqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("EditProfileDetails", _connection.SqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Id", user.Id);
                sqlCommand.Parameters.AddWithValue("@Firstname", user.Firstname);
                sqlCommand.Parameters.AddWithValue("@Middlename", user.Middlename);
                sqlCommand.Parameters.AddWithValue("@Lastname", user.Lastname);
                sqlCommand.Parameters.AddWithValue("@Birthdate", user.Birthdate);
                sqlCommand.Parameters.AddWithValue("@Country", user.Country);
                sqlCommand.Parameters.AddWithValue("@City", user.City);
                sqlCommand.Parameters.AddWithValue("@Biography", user.Biography);
                sqlCommand.ExecuteNonQuery();
                _connection.SqlConnection.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw new Exception("Had trouble connecting with the server.");
            }           
        }

        public IEnumerable<User> GetFollowers(User user)
        {
            try
            {
                _connection.SqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("GetFollowers", _connection.SqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@UserId", user.Id);
                sqlCommand.ExecuteNonQuery();
                var Friendlist = new List<User>();
                sqlCommand.ExecuteNonQuery();
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var friend = new User
                        {
                            Id = reader.GetInt32(0),
                            Firstname = reader.GetString(1),
                            Middlename = reader.GetString(2),
                            Lastname = reader.GetString(3)
                        };
                        Friendlist.Add(friend);
                    }
                }
                _connection.SqlConnection.Close();
                return Friendlist;
            }
            catch (Exception)
            {
                throw new Exception("Had trouble connecting with the server.");
            }            
        }

        public IEnumerable<User> GetFollowing(User user)
        {
            try
            {
                _connection.SqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("GetFollowing", _connection.SqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@UserId", user.Id);
                sqlCommand.ExecuteNonQuery();
                var Friendlist = new List<User>();
                sqlCommand.ExecuteNonQuery();
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var friend = new User
                        {
                            Id = reader.GetInt32(0),
                            Firstname = reader.GetString(1),
                            Middlename = reader.GetString(2),
                            Lastname = reader.GetString(3)
                        };
                        Friendlist.Add(friend);
                    }
                }
                _connection.SqlConnection.Close();
                return Friendlist;
            }
            catch (Exception)
            {
                throw new Exception("Had trouble connecting with the server.");
            }            
        }

        public bool DoesProfileExist(int Id)
        {
            try
            {
                _connection.SqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("CheckIfProfileExists", _connection.SqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@UserId", Id);
                var returnParameter = sqlCommand.Parameters.Add("@return", SqlDbType.Bit);
                returnParameter.Direction = ParameterDirection.ReturnValue;
                sqlCommand.ExecuteNonQuery();
                bool DoesExist = Convert.ToBoolean(returnParameter.Value);
                _connection.SqlConnection.Close();
                return DoesExist;
            }
            catch (Exception)
            {

                throw new Exception("Had trouble connecting with the server.");
            }
        }

        public IEnumerable<User> GetSearchResult(string Searchterm)
        {
            try
            {
                _connection.SqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("SearchUsers", _connection.SqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Searchterm", Searchterm);
                var SearchResult = new List<User>();
                sqlCommand.ExecuteNonQuery();
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var user = new User
                        {
                            Id = reader.GetInt32(0),
                            Firstname = reader.GetString(1),
                            Middlename = reader.GetString(2),
                            Lastname = reader.GetString(3),
                            Biography = reader.GetString(4),

                        };
                        var profilePicture = new ProfilePicture();
                        if (!reader.IsDBNull(5))
                        {
                            profilePicture.Image = (byte[])reader["Data"];
                        }
                        user.ProfilePicture = profilePicture;
                        SearchResult.Add(user);
                    }
                }
                _connection.SqlConnection.Close();
                return SearchResult;
            }
            catch (Exception)
            {

                throw new Exception("Had trouble connecting with the server.");
            }            
        }

        public int GetUserCount()
        {
            int userCount = 0;
            _connection.SqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("GetUserCount", _connection.SqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    userCount = reader.GetInt32(0);                 
                }
            }
            _connection.SqlConnection.Close();
            return userCount;
        }

        public int GetFollowerCount()
        {
            int followerCount = 0;
            _connection.SqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("GetAllFollowers", _connection.SqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    followerCount = reader.GetInt32(0);
                }
            }
            _connection.SqlConnection.Close();
            return followerCount;
        }

        public void DeleteUserAfterUnitTest(string username)
        {            
            DeleteProfilePicture(username);
            DeleteUser(username);
        }

        private void DeleteUser(string username)
        {
            _connection.SqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("DeleteUserAfterUnitTest", _connection.SqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Username", username);
            sqlCommand.ExecuteNonQuery();
            _connection.SqlConnection.Close();
        }

        private void DeleteProfilePicture(string username)
        {
            User user = new User();
            user.Username = username;
            user = GetSessionId(user);
            _connection.SqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("DeletePictureAfterUnitTest", _connection.SqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Id", user.Id);
            sqlCommand.ExecuteNonQuery();
            _connection.SqlConnection.Close();
        }
    }
}
