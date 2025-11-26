using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using Movies.BL;

namespace Movies.DAL
{
    public class MovieDAL
    {
        DBservice dbs = new DBservice();

        public List<Movie> GetAllMovies()
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            List<Movie> movies = new List<Movie>();

            try
            {
                con = dbs.Connect("myProjDB");
                cmd = dbs.CreateCommand("sp_InsertMovie", con);

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (reader.Read())
                {
                    Movie m = new Movie();

                    m.Id = Convert.ToInt32(reader["Id"]);
                    m.Title = reader["Title"].ToString();
                    m.Rating = Convert.ToDouble(reader["Rating"]);
                    m.Income = Convert.ToDouble(reader["Income"]); 
                    m.ReleaseYear = Convert.ToInt32(reader["ReleaseYear"]);
                    m.Duration = Convert.ToInt32(reader["Duration"]);
                    m.Language = reader["Language"].ToString();
                    m.Description = reader["Description"].ToString();
                    m.Genre = reader["Genre"].ToString();
                    m.PhotoUrl = reader["PhotoUrl"].ToString();

                    movies.Add(m);
                }

                return movies;
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

        public bool InsertMovie(Movie movie)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;

            try
            {
                con = dbs.Connect("myProjDB");
                cmd = dbs.CreateCommand("sp_InsertMovie", con);

                cmd.Parameters.AddWithValue("@Title", movie.Title);
                cmd.Parameters.AddWithValue("@Rating", movie.Rating);
                cmd.Parameters.AddWithValue("@Income", movie.Income);
                cmd.Parameters.AddWithValue("@ReleaseYear", movie.ReleaseYear);
                cmd.Parameters.AddWithValue("@Duration", movie.Duration);
                cmd.Parameters.AddWithValue("@Language", movie.Language);
                cmd.Parameters.AddWithValue("@Description", movie.Description);
                cmd.Parameters.AddWithValue("@Genre", movie.Genre);
                cmd.Parameters.AddWithValue("@PhotoUrl", movie.PhotoUrl);

                int numEff = cmd.ExecuteNonQuery();
                return numEff > 0;
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
