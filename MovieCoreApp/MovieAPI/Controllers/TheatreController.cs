using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Business.Services;
using MovieAPI.Controllers;
using MovieApp.Entity;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheatreController : ControllerBase
    {
        TheatreService _theatreService;

        public TheatreController(TheatreService theatreService)
        {
            _theatreService= theatreService;
        }

        [HttpGet("SelectTheatres")]
        public IActionResult SelectTheatres()
        {
            return Ok(_theatreService.SelectTheatres()); ;
        }

        [HttpPost("Register") ]

        public IActionResult Register(TheatreModel theatreModel)
        {
            return Ok(_theatreService.Register(theatreModel));
        }

        [HttpDelete("DeleteTheatre")]
         
        public IActionResult DeleteTheatre(int theatreId)
        {
            return Ok(_theatreService.DeleteTheatre(theatreId));      
        }

        [HttpPut("UpdateTheatre")]
        public IActionResult UpdateTheatre(TheatreModel theatreModel)
        {
            return Ok(_theatreService.UpdateTheatre(theatreModel));

        }

        [HttpGet("SelectTheatreById")]

        public IActionResult SelectTheatreById(int theatreId)
        {
            return Ok(_theatreService.SelectTheatreById(theatreId));   
        }

    }
}
