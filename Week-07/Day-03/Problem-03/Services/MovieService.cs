using WebApplication2.Models;
using WebApplication2.Repositories;

namespace WebApplication2.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repo;
        public MovieService(IMovieRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Movies> GetMovies()
        {

            return _repo.GetAllMovies();
        }
        public Movies GetMovieById(int id)
        {
            return _repo.GetById(id);
        }
         public void CreateMovie(Movies movies)
        {
            _repo.Add(movies);
        }
        public void UpdateMovie(Movies movies)
        {
            _repo.Update(movies);
        }
        public void DeleteMovie(int id)
        {
            _repo.Delete(id);
        }
    }
}
