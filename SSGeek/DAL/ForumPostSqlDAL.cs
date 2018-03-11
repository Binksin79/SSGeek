using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SSGeek.Models;
using System.Data.SqlClient;

namespace SSGeek.DAL
{
    public class ForumPostSqlDAL : IForumPostDAL
    {

        private string connectionString;

        public ForumPostSqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<ForumPost> GetAllPosts()
        {
            List<ForumPost> list = new List<ForumPost>();

            string forumPostQuery = @"Select * from forum_post ORDER BY post_date DESC";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(forumPostQuery, conn);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(MapRowToForumPost(reader));
                }
            }

            return list;
        }

        public bool SaveNewPost(ForumPost forumPost)
        {
            
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO forum_post VALUES (@username, @subject, @message, @postdate);", conn);

                cmd.Parameters.AddWithValue("@username", forumPost.Username);
                cmd.Parameters.AddWithValue("@subject", forumPost.Subject);
                cmd.Parameters.AddWithValue("@message", forumPost.Message);
                cmd.Parameters.AddWithValue("@postdate", DateTime.Now);

                cmd.ExecuteNonQuery();
            }

            return true;



        }


        private ForumPost MapRowToForumPost(SqlDataReader reader)
        {
            return new ForumPost()
            {
                Subject = Convert.ToString(reader["subject"]),
                Username = Convert.ToString(reader["username"]),
                PostDate = Convert.ToDateTime(reader["post_date"]),
                Message = Convert.ToString(reader["message"])
            };

        }


        //public void PostToForum(ForumPost forumPost)
        //{          
        //   using (SqlConnection conn = new SqlConnection(connectionString))
        //   {
        //        conn.Open();

        //        SqlCommand cmd = new SqlCommand("INSERT INTO forum_post VALUES (@username, @subject, @message, @postdate);", conn);

        //        cmd.Parameters.AddWithValue("@username", forumPost.Username);
        //        cmd.Parameters.AddWithValue("@subject", forumPost.Subject);
        //        cmd.Parameters.AddWithValue("@message", forumPost.Message);
        //        cmd.Parameters.AddWithValue("@postdate", DateTime.Now);

        //        cmd.ExecuteNonQuery();
        //   }
        //}

    }
}