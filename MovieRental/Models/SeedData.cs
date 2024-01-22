using Microsoft.EntityFrameworkCore;
using MovieRental.Data;

namespace MovieRental.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MovieRentalContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MovieRentalContext>>()))
        {
            if (context.Movie.Any())
            {
                return;   
            }
            context.Movie.AddRange(
                new Movie
                {
                    Name = "When Harry Met Sally",
                    Genre = "Romantic Comedy",
                    Price = 45.99M,
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    ImageUri = "https://placehold.co/100x100"
                },
                new Movie
                {
                    Name = "Ghostbusters ",
                    Genre = "Comedy",
                    Price = 32.99M,
                    ReleaseDate = DateTime.Parse("1984-3-13"),
                    ImageUri = "https://placehold.co/100x100"
                },
                new Movie
                {
                    Name = "Ghostbusters 2",
                    Genre = "Comedy",
                    Price = 16.99M,
                    ReleaseDate = DateTime.Parse("1986-2-23"),
                    ImageUri = "https://placehold.co/100x100"
                },
                new Movie
                {
                    Name = "Rio Bravo",
                    Genre = "Western",
                    Price = 25.99M,
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    ImageUri = "https://placehold.co/100x100"
                }
            );
            context.SaveChanges();
        }
    }
}