using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Interfaces;
using WebApp.Models;

namespace WebApp.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class Movies1Controller : ControllerBase
    {
        private readonly IMovies _moviesrepository;
        public Movies1Controller(IMovies moviesrepository)
        {
            _moviesrepository = moviesrepository;
        }

        [HttpGet]
        // GET: Movies1
        public async Task<ActionResult> GetMovies()
        {
            try
            {
                var movies = await _moviesrepository.GetMovies();
                return Ok(movies);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET: Movies1/Details/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovieById(int id)
        {
            try
            {
                var movie = await _moviesrepository.GetMovieById(id);
                if (movie == null)
                    return NotFound();
                return Ok(movie);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Movie>> AddMovie([FromBody] Movie movie)
        {
            try
            {
                var addedmovie = await _moviesrepository.AddMovie(movie);
                return Ok(addedmovie);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Movie>> UpdateMovie([FromBody] Movie movie)
        {
            try
            {
                await _moviesrepository.UpdateMovie(movie);
                return Ok(movie);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteMovie([FromBody]int id)
        {
            try
            {
                await _moviesrepository.DeleteMovie(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }    
        }
    }    
}
