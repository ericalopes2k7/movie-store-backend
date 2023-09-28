using Microsoft.AspNetCore.Mvc;
using movie_store_backend.Services.IServices;

namespace movie_store_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpPost]
        public ActionResult CreateMovie()
        {
            return StatusCode(StatusCodes.Status201Created, "Movie created");
        }

        [HttpGet]
        public ActionResult FindMovie()
        {
            return StatusCode(StatusCodes.Status200OK, "Movie found");
        }

        [HttpGet("search")]
        public ActionResult FindMovies()
        {
            return StatusCode(StatusCodes.Status200OK, "Movies found");
        }

        [HttpGet("all")]
        public ActionResult FindAllMovies()
        {
            return StatusCode(StatusCodes.Status200OK, "All Movies were found");
        }

        [HttpPut]
        public ActionResult UpdateMovie()
        {
            return StatusCode(StatusCodes.Status200OK, "Movie updated");
        }

        [HttpDelete]
        public ActionResult DeleteMovie()
        {
            return StatusCode(StatusCodes.Status200OK, "Movie deleted");
        }
    }
}
