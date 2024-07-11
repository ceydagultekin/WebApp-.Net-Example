using WebApp.Models;

namespace WebApp.Interfaces
{
    public interface IMovies
    {
        Task<IEnumerable<Movie>> GetMovies();
        Task<Movie> GetMovieById(int id);
        Task DeleteMovie(int id);
        Task <Movie> AddMovie(Movie movie);
        Task <Movie> UpdateMovie(Movie movie);

    }
}
