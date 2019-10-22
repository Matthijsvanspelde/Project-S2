using Microsoft.Data.SqlClient;
using SocialNetwork.DAL.App_data;
using SocialNetwork.DAL.IContexts;
using SocialNetwork.Models;
using System.Data;
using System.IO;

namespace SocialNetwork.DAL.Contexts
{
    public class ProfilePictureContext: IProfilePictureContext
    {
        private readonly Connection _connection;

        public ProfilePictureContext(Connection connection)
        {
            _connection = connection;
        }

        public void UploadPicture(ProfilePicture profilePicture, User user)
        {
            _connection.SqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("SetProfilePicture", _connection.SqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Image", profilePicture.Image);
            sqlCommand.Parameters.AddWithValue("@UserId", user.Id);
            sqlCommand.Parameters.AddWithValue("@FileType", profilePicture.FileType);
            sqlCommand.ExecuteNonQuery();
            _connection.SqlConnection.Close();
        }

        public ProfilePicture GetProfilePicture(User user)
        {
            ProfilePicture profilePicture = new ProfilePicture();
            _connection.SqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("GetProfilePicture", _connection.SqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@UserId", user.Id);
            sqlCommand.ExecuteNonQuery();
            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    profilePicture.Image = (byte[])reader["Data"];
                }
            }
            _connection.SqlConnection.Close();
            return profilePicture;
        }
    }
}
