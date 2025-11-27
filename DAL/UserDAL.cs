using System;
using System.Data;
using Microsoft.Data.SqlClient;
using Movies.BL;

namespace Movies.DAL
{
    public class UserDAL
    {
        DBservice dbs = new DBservice();

        public bool RegisterUser(User user)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;

            try
            {
                con = dbs.Connect("myProjDB");
                cmd = dbs.CreateCommand("sp_RegisterUser", con);

                cmd.Parameters.AddWithValue("@UserName", user.UserName);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Password", user.Password);

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("Email already exists"))
                    return false;

                if (ex.Number == 2627 || ex.Number == 2601)
                    return false;

                throw;
            }
            finally
            {
                if (con != null)
                    con.Close();
            }
        }


        public User LoginUser(string email, string password)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;

            try
            {
                con = dbs.Connect("myProjDB");
                cmd = dbs.CreateCommand("LoginUser_sp", con);

                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                if (reader.Read())
                {
                    User u = new User();
                    u.Id = Convert.ToInt32(reader["Id"]);
                    u.UserName = reader["UserName"].ToString();
                    u.Email = reader["Email"].ToString();
                    reader.Close();
                    return u;
                }
                reader.Close();
                return null;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (con != null)
                    con.Close();
            }
        }
    }
}
