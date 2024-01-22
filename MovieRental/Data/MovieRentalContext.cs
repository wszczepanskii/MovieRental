using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieRental.Models;

namespace MovieRental.Data
{
    public class MovieRentalContext : DbContext
    {
        public MovieRentalContext (DbContextOptions<MovieRentalContext> options)
            : base(options)
        {
        }

        public DbSet<MovieRental.Models.Movie> Movie { get; set; } = default!;
    }
}
