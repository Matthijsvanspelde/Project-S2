using Microsoft.Data.SqlClient;
using SocialNetwork.DAL.App_data;
using SocialNetwork.DAL.IContexts;
using SocialNetwork.Models;
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

        public FriendRequest SendFriendRequest(FriendRequest friendRequest)
        {
            _connection.SqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("SendFriendRequest", _connection.SqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@SenderId", friendRequest.SenderId);
            sqlCommand.Parameters.AddWithValue("@RecieverId", friendRequest.RevieverId);
            sqlCommand.Parameters.AddWithValue("@TimeSend", friendRequest.Recieved);
            sqlCommand.ExecuteNonQuery();
            _connection.SqlConnection.Close();
            return friendRequest;
        }

        public int CheckDublicateFriendRequest(FriendRequest friendRequest)
        {
            _connection.SqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("CheckDublicateFriendRequest", _connection.SqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@SenderId", friendRequest.SenderId);
            sqlCommand.Parameters.AddWithValue("@RecieverId", friendRequest.RevieverId);
            var returnParameter = sqlCommand.Parameters.Add("@Count", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;
            sqlCommand.ExecuteNonQuery();
            int RequestCount = (int)returnParameter.Value;
            _connection.SqlConnection.Close();
            return RequestCount;
        }
    }
}
