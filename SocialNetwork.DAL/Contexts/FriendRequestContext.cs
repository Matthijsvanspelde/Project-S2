using Microsoft.Data.SqlClient;
using SocialNetwork.DAL.App_data;
using SocialNetwork.DAL.IContexts;
using SocialNetwork.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace SocialNetwork.DAL.Contexts
{
    public class FriendRequestContext : IFriendRequestContext
    {
        private readonly Connection _connection;

        public FriendRequestContext(Connection connection)
        {
            _connection = connection;
        }

        public bool SendFriendRequest(FriendRequest friendRequest)
        {
            try
            {
                _connection.SqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("SendFriendRequest", _connection.SqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@SenderId", friendRequest.SenderId);
                sqlCommand.Parameters.AddWithValue("@RecieverId", friendRequest.RecieverId);
                sqlCommand.Parameters.AddWithValue("@TimeSend", friendRequest.Recieved);
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

        public bool DoesFriendRequestExist(FriendRequest friendRequest)
        {
            try
            {
                _connection.SqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("CheckDublicateFriendRequest", _connection.SqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@SenderId", friendRequest.SenderId);
                sqlCommand.Parameters.AddWithValue("@RecieverId", friendRequest.RecieverId);
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

        public bool IsFollowing(FriendRequest friendRequest)
        {
            try
            {
                _connection.SqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("CheckIfFollowing", _connection.SqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Follower", friendRequest.SenderId);
                sqlCommand.Parameters.AddWithValue("@Followed", friendRequest.RecieverId);
                var returnParameter = sqlCommand.Parameters.Add("@return", SqlDbType.Bit);
                returnParameter.Direction = ParameterDirection.ReturnValue;
                sqlCommand.ExecuteNonQuery();
                bool IsFollowing = Convert.ToBoolean(returnParameter.Value);
                _connection.SqlConnection.Close();
                return IsFollowing;
            }
            catch (Exception)
            {
                throw new Exception("Had trouble connecting with the server.");
            }            
        }

        public IEnumerable<FriendRequest> GetFriendRequests(FriendRequest friendRequest)
        {
            try
            {
                _connection.SqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("GetFriendRequests", _connection.SqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@RecieverId", friendRequest.RecieverId);
                var Requests = new List<FriendRequest>();
                sqlCommand.ExecuteNonQuery();
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var request = new FriendRequest
                        {
                            SenderId = reader.GetInt32(0),
                            Firstname = reader.GetString(1),
                            Middlename = reader.GetString(2),
                            Lastname = reader.GetString(3),
                            Recieved = reader.GetDateTime(4),
                        };
                        Requests.Add(request);
                    }
                }
                _connection.SqlConnection.Close();
                return Requests;
            }
            catch (Exception)
            {
                throw new Exception("Had trouble connecting with the server.");
            }            
        }

        public void AcceptFriendRequest(FriendRequest friendRequest)
        {
            try
            {
                _connection.SqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("SetFriendship", _connection.SqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@SenderId", friendRequest.SenderId);
                sqlCommand.Parameters.AddWithValue("@RecieverId", friendRequest.RecieverId);
                sqlCommand.Parameters.AddWithValue("@TimeSend", friendRequest.Recieved);
                sqlCommand.ExecuteNonQuery();
                _connection.SqlConnection.Close();
                DeleteFriendRequest(friendRequest);
            }
            catch (Exception)
            {
                throw new Exception("Had trouble connecting with the server.");
            }            
        }

        public void DeleteFriendRequest(FriendRequest friendRequest)
        {
            try
            {
                _connection.SqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("DenyFriendRequest", _connection.SqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@SenderId", friendRequest.SenderId);
                sqlCommand.Parameters.AddWithValue("@RecieverId", friendRequest.RecieverId);
                sqlCommand.ExecuteNonQuery();
                _connection.SqlConnection.Close();
            }
            catch (Exception)
            {
                throw new Exception("Had trouble connecting with the server.");
            }            
        }
    }
}
