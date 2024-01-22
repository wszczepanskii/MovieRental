using Microsoft.EntityFrameworkCore;
using MovieRental.Areas.Identity.Data;

namespace MovieRental.Data
{
    public class MovieRentalContext : LoginContext
    {
        public MovieRentalContext (DbContextOptions<MovieRentalContext> options)
            : base(options)
        {
        }

        public DbSet<MovieRental.Models.Movie> Movie { get; set; } = default!;
    }
}
