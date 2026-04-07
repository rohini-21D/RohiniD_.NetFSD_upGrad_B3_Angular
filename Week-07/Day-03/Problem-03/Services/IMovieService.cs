using WebApplication2.Models;

namespace WebApplication2.Services
{
    public interface IMovieService
    {
        IEnumerable<Movies> GetMovies();
        Movies GetMovieById(int id);
        void CreateMovie(Movies movies);
        void UpdateMovie(Movies movies);
        void DeleteMovie(int id);
    }
}
