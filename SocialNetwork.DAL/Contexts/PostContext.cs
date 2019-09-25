using Microsoft.Data.SqlClient;
using SocialNetwork.DAL.App_data;
using SocialNetwork.DAL.IContexts;
using SocialNetwork.Models;
using System.Collections.Generic;
using System.Data;

namespace SocialNetwork.DAL.Contexts
{
    public class PostContext : IPostContext
    {
        private readonly Connection _connection;

        public PostContext(Connection connection)
        {
            _connection = connection;
        }

        public void SetPost(Post post, User user)
        {
            _connection.SqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("SetPost", _connection.SqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Title", post.Title);
            sqlCommand.Parameters.AddWithValue("@Message", post.Message);
            sqlCommand.Parameters.AddWithValue("@UserId", user.Id);
            sqlCommand.Parameters.AddWithValue("@DateTime", post.Posted);
            sqlCommand.ExecuteNonQuery();
            _connection.SqlConnection.Close();
        }

        public IEnumerable<Post> GetPost(User user)
        {
            _connection.SqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("Getpost", _connection.SqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@UserId", user.Id);
            var Posts = new List<Post>();
            sqlCommand.ExecuteNonQuery();
            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    var post = new Post
                    {
                        Title = reader.GetString(0),
                        Message = reader.GetString(1),
                        Firstname = reader.GetString(2),
                        Middlename = reader.GetString(3),
                        Lastname = reader.GetString(4),
                        Posted = reader.GetDateTime(5),
                        Likes = reader.GetInt32(6),
                    };
                    Posts.Add(post);
                }
            }
            _connection.SqlConnection.Close();
            return Posts;
        }
    }
}
