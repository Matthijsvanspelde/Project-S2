using Microsoft.Data.SqlClient;
using SocialNetwork.DAL.App_data;
using SocialNetwork.DAL.IContexts;
using SocialNetwork.Models;
using System.Data;

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
            sqlCommand.ExecuteNonQuery();
            _connection.SqlConnection.Close();
        }
    }
}
