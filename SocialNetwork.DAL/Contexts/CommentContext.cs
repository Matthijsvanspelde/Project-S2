using Microsoft.Data.SqlClient;
using SocialNetwork.DAL.App_data;
using SocialNetwork.DAL.IContexts;
using SocialNetwork.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace SocialNetwork.DAL.Contexts
{
    public class CommentContext: ICommentContext
    {
        private readonly Connection _connection;

        public CommentContext(Connection connection)
        {
            _connection = connection;
        }

        public void SetComment(Comment comment, Post post, User user)
        {
            try
            {
                _connection.SqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("SetPostComment", _connection.SqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Message", comment.Message);
                sqlCommand.Parameters.AddWithValue("@Posted", comment.Posted);
                sqlCommand.Parameters.AddWithValue("@PostId", post.PostId);
                sqlCommand.Parameters.AddWithValue("@UserId", user.Id);
                sqlCommand.ExecuteNonQuery();
                _connection.SqlConnection.Close();
            }
            catch (Exception)
            {
                throw new Exception("Had trouble connecting with the server.");
            }            
        }

        public IEnumerable<Comment> GetComment(User user)
        {
            try
            {
                _connection.SqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("GetComment", _connection.SqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@UserId", user.Id);
                var Comments = new List<Comment>();
                sqlCommand.ExecuteNonQuery();
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var comment = new Comment
                        {
                            Message = reader.GetString(1),
                            Posted = reader.GetDateTime(2),
                            Firstname = reader.GetString(3),
                            Middlename = reader.GetString(4),
                            Lastname = reader.GetString(3),
                        };
                        Comments.Add(comment);
                    }
                }
                _connection.SqlConnection.Close();
                return Comments;
            }
            catch (Exception)
            {
                throw new Exception("Had trouble connecting with the server.");
            }            
        }
    }
}
