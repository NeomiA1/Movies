using System;
using System.Collections.Generic;
using System.Linq;
using Movies.DAL; 

namespace Movies.BL
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Rating { get; set; }
        public double Income { get; set; }
        public int ReleaseYear { get; set; }
        public int Duration { get; set; }
        public string Language { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public string PhotoUrl { get; set; }

                private static readonly MovieDAL dal = new MovieDAL();

        public bool Insert()
        {

            bool success = dal.InsertMovie(this);
            return success;
        }

        public static List<Movie> Read()
        {
            return dal.GetAllMovies();
        }

        public static List<Movie> ReadByRating(double minRating)
        {
            List<Movie> all = dal.GetAllMovies();

            return all
                .Where(m => m.Rating >= minRating)
                .ToList();
        }
    }
}
