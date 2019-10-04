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

        public void LikePost(Post post, User user)
        {
            _connection.SqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("LikePost", _connection.SqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@PostId", post.PostId);
            sqlCommand.Parameters.AddWithValue("@UserId", user.Id);
            sqlCommand.ExecuteNonQuery();
            _connection.SqlConnection.Close();
        }

        public int CheckDublicateLike(Post post, User user)
        {
            _connection.SqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("CheckDublicateLikes", _connection.SqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@PostId", post.PostId);
            sqlCommand.Parameters.AddWithValue("@UserId", user.Id);
            var returnParameter = sqlCommand.Parameters.Add("@Count", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;
            sqlCommand.ExecuteNonQuery();
            int LikeCount = (int)returnParameter.Value;
            _connection.SqlConnection.Close();
            return LikeCount;
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
                        PostId = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        Message = reader.GetString(2),
                        Firstname = reader.GetString(3),
                        Middlename = reader.GetString(4),
                        Lastname = reader.GetString(5),
                        Posted = reader.GetDateTime(6),
                        Likes = reader.GetInt32(7),
                    };
                    Posts.Add(post);
                }
            }
            _connection.SqlConnection.Close();
            return Posts;
        }

        public IEnumerable<Post> GetFollowingPosts(User user)
        {
            _connection.SqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("GetFollowingPosts", _connection.SqlConnection);
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
                        UserId = reader.GetInt32(0),
                        PostId = reader.GetInt32(1),
                        Title = reader.GetString(2),
                        Message = reader.GetString(3),
                        Posted = reader.GetDateTime(4),
                        Likes = reader.GetInt32(5),
                        Firstname = reader.GetString(6),
                        Middlename = reader.GetString(7),
                        Lastname = reader.GetString(8),                                              
                    };
                    Posts.Add(post);
                }
            }
            _connection.SqlConnection.Close();           
            return Posts;
        }

    }
}
