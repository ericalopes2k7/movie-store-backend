using Microsoft.AspNetCore.Mvc;
using movie_store_backend.DTOs;
using movie_store_backend.Services.IServices;
using System.Diagnostics;

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
        public async Task<ActionResult> CreateMovie(MovieRequestBody dto)
        {
            try
            {
                var result = await _movieService.CreateMovie(dto);
                if (!result.isSuccess)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, result.errorMessage);
                }

                return StatusCode(StatusCodes.Status201Created, result.value);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        [HttpGet]
        public async Task<ActionResult> FindMovie([FromQuery(Name = "id")] string id)
        {
            try
            {
                var result = await _movieService.FindMovie(id);
                if (!result.isSuccess)
                {
                    return StatusCode(StatusCodes.Status404NotFound, result.errorMessage);
                }

                return StatusCode(StatusCodes.Status200OK, result.value);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        [HttpGet("search")]
        public async Task<ActionResult> FindMovies([FromQuery(Name = "title")] string title)
        {
            Debug.WriteLine(title);
            try
            {
                var result = await _movieService.FindMovies(title);
                if (!result.isSuccess)
                {
                    return StatusCode(StatusCodes.Status404NotFound, result.errorMessage);
                }

                return StatusCode(StatusCodes.Status200OK, result.value);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        [HttpGet("all")]
        public async Task<ActionResult> FindAllMovies()
        {
            try
            {
                var result = await _movieService.FindAllMovies();
                if (!result.isSuccess)
                {
                    return StatusCode(StatusCodes.Status404NotFound, result.errorMessage);
                }

                return StatusCode(StatusCodes.Status200OK, result.value);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateMovie([FromQuery(Name = "id")] string id, MovieRequestBody dto)
        {
            try
            {
                var result = await _movieService.UpdateMovie(id, dto);
                if (!result.isSuccess)
                {
                    return StatusCode(StatusCodes.Status404NotFound, result.errorMessage);
                }

                return StatusCode(StatusCodes.Status200OK, result.value);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteMovie([FromQuery(Name = "id")] string id)
        {
            try
            {
                var result = await _movieService.DeleteMovie(id);
                if (!result.isSuccess)
                {
                    return StatusCode(StatusCodes.Status404NotFound, result.errorMessage);
                }

                return StatusCode(StatusCodes.Status200OK, result.value);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }
    }
}
