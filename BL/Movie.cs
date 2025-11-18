using System;
using System.Collections.Generic;
using System.Linq;

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

        public static List<Movie> moviesList = new List<Movie>();

        // Seed movies for testing (לא חובה במטלה, אבל מעולה לבדיקה)
        static Movie()
        {
            moviesList.Add(new Movie
            {
                Id = 1,
                Title = "Inception",
                Rating = 8.8,
                Income = 830,
                ReleaseYear = 2010,
                Duration = 148,
                Language = "English",
                Description = "Dreams inside dreams",
                Genre = "Sci-Fi",
                PhotoUrl = ""
            });

            moviesList.Add(new Movie
            {
                Id = 2,
                Title = "Toy Story",
                Rating = 8.3,
                Income = 400,
                ReleaseYear = 1995,
                Duration = 81,
                Language = "English",
                Description = "Animated toys",
                Genre = "Animation",
                PhotoUrl = ""
            });

            moviesList.Add(new Movie
            {
                Id = 3,
                Title = "Test Movie",
                Rating = 5.2,
                Income = 50,
                ReleaseYear = 2005,
                Duration = 90,
                Language = "English",
                Description = "Test",
                Genre = "Drama",
                PhotoUrl = ""
            });
        }

        public bool Insert()
        {
            foreach (Movie movie in moviesList)
            {
                if (movie.Id == this.Id)
                {
                    throw new Exception("Movie is already exists");
                }
            }

            moviesList.Add(this);
            return true;
        }

        public static List<Movie> Read()
        {
            return moviesList;
        }

        public static List<Movie> ReadByRating(double minRating)
        {
            return moviesList
                .Where(m => m.Rating >= minRating)
                .ToList();
        }
    }
}
