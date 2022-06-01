using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Business.Services;
using MovieApp.Entity;

namespace MovieAPI.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        // to acess service i.e business layer here concept of D.I (ctor based DI)

        MovieService _movieService;

        public MovieController(MovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("SelectMovies")]

        public IActionResult SelectMovies()
        {
            return Ok(_movieService.SelectMovies()) ;      
        }

        [HttpPost("Register")]

        public IActionResult Register(MovieModel movieModel)
        {
            return Ok(_movieService.Register(movieModel));
            
        }

        [HttpDelete("DeleteMovie")]

        public IActionResult DeleteMovie(int movieId)
        {
            return Ok(_movieService.DeleteMovie(movieId));

        }

        [HttpPut("UpdateMovie")]
        public IActionResult UpdateMovie(MovieModel movieModel)
        {
            return Ok(_movieService.UpdateMovie(movieModel));
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] MovieModel movieModel)
        {
            return Ok(_movieService.Login(movieModel));
        }

        [HttpGet("SelectMovieById")]

        public IActionResult SelectMovieById(int movieId)
        {
            return Ok(_movieService.SelectMovieById(movieId));
        }
    }
}
