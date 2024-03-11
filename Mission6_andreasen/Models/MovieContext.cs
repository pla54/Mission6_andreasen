using Microsoft.EntityFrameworkCore;

namespace Mission6_andreasen.Models
{

    //File to create the context connection for category and movie
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base (options)
        {

        }

        public  DbSet<Movie> Movies { get; set; }

        public DbSet<Category> Categories { get; set; }


    }
}
