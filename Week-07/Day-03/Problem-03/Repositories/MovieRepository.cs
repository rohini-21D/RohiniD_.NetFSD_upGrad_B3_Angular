using WebApplication2.Models;

namespace WebApplication2.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly AppDbContext _context;
        public MovieRepository(AppDbContext context)
        {
            _context = context;
        }
       
        public IEnumerable<Movies> GetAllMovies()
        {
            var movies = _context.Movies.ToList();
            return movies;
        }
        public Movies GetById(int id)
        {
            return _context.Movies.Find(id);
        }

        public void Add(Movies movies)
        {
            _context.Movies.Add(movies);
            _context.SaveChanges();
        }
        public void Update(Movies movies)
        {
            _context.Movies.Update(movies);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var movie = _context.Movies.Find(id);

            if (movie != null)
            {
                _context.Movies.Remove(movie);
                _context.SaveChanges();
            }
        }
    }

}
