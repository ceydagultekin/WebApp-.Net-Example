using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApp.Interfaces;
using WebApp.Models;


namespace WebApp.Repositories
{
    public class Movies1Repository:IMovies
    {
        private readonly MovieContext _dbContext;
        private readonly IMapper _mapper;
        public Movies1Repository(MovieContext context,IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        public async Task<Movie> AddMovie(Movie Movie)
        {
            if (Movie == null) throw new InvalidCastException("Film bilgileri eksik !");

            var movie=_mapper.Map<Movie>(Movie);
            await _dbContext.Movies.AddAsync(movie);
            await _dbContext.SaveChangesAsync();
            return movie;
        }

        public async Task<Movie> UpdateMovie(Movie Movie)
        {
            if (Movie is null)
                throw new InvalidOperationException("Film Mevcut Değil.");

            var movie = _mapper.Map<Movie>(Movie);
             _dbContext.Movies.Update(movie);
            await _dbContext.SaveChangesAsync();
            return movie;
        }

        public async Task DeleteMovie(int id)
        {
            var movie = await _dbContext.Movies.FirstOrDefaultAsync(x => x.Id == id);
            if (movie is null)
            {
                throw new InvalidOperationException("Böyle Bir Film Mevcut Değil.");
            }

            _dbContext.Remove(movie);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Movie>> GetMovies()
        {
          return await _dbContext.Movies.ToListAsync();
        }

        public async Task<Movie> GetMovieById(int MovieId)
        {
            return await _dbContext.Movies.FirstOrDefaultAsync(x => x.Id == MovieId);
        }
        
    }
}
