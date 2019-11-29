using Microsoft.Data.SqlClient;
using SocialNetwork.DAL.App_data;
using SocialNetwork.DAL.IContexts;
using SocialNetwork.Models;
using System;
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
            try
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
            catch (Exception)
            {
                throw new Exception("Had trouble connecting with the server.");
            }            
        }

        public ProfilePicture GetProfilePicture(User user)
        {
            try
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
                        if (!reader.IsDBNull(0))
                        {
                            profilePicture.Image = (byte[])reader["Data"];
                        }
                    }
                }
                _connection.SqlConnection.Close();
                return profilePicture;
            }
            catch (Exception)
            {
                throw new Exception("Had trouble connecting with the server.");
            }            
        }              
    }
}
