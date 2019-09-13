using Microsoft.Data.SqlClient;
using SocialNetwork.DAL.App_data;
using SocialNetwork.DAL.IContexts;
using SocialNetwork.Models;
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

        public User RegisterUser(User user)
        {
            _connection.SqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("RegisterUser", _connection.SqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Username", user.Username);
            sqlCommand.Parameters.AddWithValue("@Password", user.Password);
            sqlCommand.Parameters.AddWithValue("@Firstname", user.Firstname);
            sqlCommand.Parameters.AddWithValue("@Lastname", user.Lastname);
            sqlCommand.Parameters.AddWithValue("@Birthdate", user.Birthdate);
            sqlCommand.ExecuteNonQuery();
            _connection.SqlConnection.Close();
            return user;
        }

        public int CheckDublicate(User user)
        {
            _connection.SqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("CheckDublicate", _connection.SqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Username", user.Username);
            var returnParameter = sqlCommand.Parameters.Add("@Count", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;
            sqlCommand.ExecuteNonQuery();
            int UserCount = (int)returnParameter.Value;
            _connection.SqlConnection.Close();
            return UserCount;
        }

        public int VerifyUser(User user)
        {
            _connection.SqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("VerifyUser", _connection.SqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Username", user.Username);
            sqlCommand.Parameters.AddWithValue("@Password", user.Password);
            var returnParameter = sqlCommand.Parameters.Add("@Count", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;
            sqlCommand.ExecuteNonQuery();
            int UserCount = (int)returnParameter.Value;
            _connection.SqlConnection.Close();
            return UserCount;
        }


        public User GetUser(User user)
        {
            _connection.SqlConnection.Open();
            SqlCommand sqlCmd = new SqlCommand("GetUser", _connection.SqlConnection);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@Username", user.Username);
            sqlCmd.ExecuteNonQuery();
            using (SqlDataReader reader = sqlCmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    user.Id = reader.GetInt32(0);
                    user.Firstname = reader.GetString(1);
                    user.Lastname = reader.GetString(1);
                }
            }
            _connection.SqlConnection.Close();
            return user;
        }
    }
}
