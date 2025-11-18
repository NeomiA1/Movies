using Microsoft.AspNetCore.Mvc;
using Movies.BL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            List<Movie> moviesList = Movie.Read();
            return Ok(moviesList);
        }

        [HttpGet("rating/{minRating}")]
        public IActionResult ReadByRating(double minRating)
        {
            var results = Movie.ReadByRating(minRating);
            return Ok(results);
        }

        [HttpGet("duration")]
        public IActionResult ReadByDuration([FromQuery] int maxDuration)
        {
            List<Movie> moviesList = Movie.Read();

            var results = moviesList
                .Where(movie => movie.Duration <= maxDuration)
                .ToList();

            return Ok(results);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Movie m)
        {
            try
            {
                bool success = m.Insert();
                if (success)
                {
                    return Created();
                }
                else
                {
                    return BadRequest("Movie already exists.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        public static List<Movie> WishList = new List<Movie>();

        [HttpPost("wishlist")]
        public IActionResult AddToWishList([FromBody] Movie m)
        {
            if (!WishList.Any(x => x.Id == m.Id))
            {
                WishList.Add(m);
                return Ok();
            }

            return BadRequest("Movie already in wish list");
        }

        [HttpGet("wishlist")]
        public IActionResult GetWishList()
        {
            return Ok(WishList);
        }
    }
}
