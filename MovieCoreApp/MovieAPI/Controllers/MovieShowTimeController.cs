using Microsoft.AspNetCore.Mvc;
using MovieApp.Business.Services;
using MovieApp.Entity;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieShowTimeController: ControllerBase
    {
        MovieShowTimeService _MovieShowTimeService;

        public MovieShowTimeController(MovieShowTimeService movieShowTimeService)
        {
            _MovieShowTimeService = movieShowTimeService;
        }

        [HttpGet("ShowMovieShowTimeList")]
        public IActionResult ShowMovieShowTimeList()
        {
            return Ok(_MovieShowTimeService.ShowMovieShowTimeList());
        }

        //[HttpPost("InsertMovieShowTime")]
        //public IActionResult InsertMovieShowTime(MovieShowTimeModel movieShowTimeModel)
        //{
        //    return Ok(_MovieShowTimeService.InsertMovieShowTime(movieShowTimeModel));
        //}

        [HttpPost("InsertMovieShowTimeList")]
        public IActionResult InsertMovieShowTimeList(MovieShowTimeModel movieShowTimeModel)
        {
            return Ok(_MovieShowTimeService.InsertMovieShowTime(movieShowTimeModel));
        }

        [HttpGet("SelectMovieShowTimeById")]
        public IActionResult SelectMovieShowTimeById(int ShowId)
        {
            return Ok(_MovieShowTimeService.SelectMovieShowTimeById(ShowId));
        }

        [HttpPut("UpdateMovieShowTime")]
        public IActionResult UpdateMovieShowTime(MovieShowTimeModel movieShowTimeModel)
        {
            return Ok(_MovieShowTimeService.UpdateMovieShowTime(movieShowTimeModel));
        }

        [HttpDelete("DeleteMovieShowTime")]
        public IActionResult DeleteMovieShowTime(int ShowId)
        {
            return Ok(_MovieShowTimeService.DeleteMovieShowTime(ShowId));
        }


    }
}
