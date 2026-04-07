using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Repositories
{
    public interface IMovieRepository
    {
       
        IEnumerable<Movies> GetAllMovies();
        Movies GetById(int id);
        void Add(Movies movies);
        void Update(Movies movies);
        void Delete(int id);
    }
}
