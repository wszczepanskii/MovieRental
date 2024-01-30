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
                    Actors = "Billy Crystal, Meg Ryan, Carrie Fisher",
                    Description = "Harry and Sally have known each other for years, and are very good friends, but they fear sex would ruin the friendship.",
                    ImageUri = "https://placehold.co/100x100"
                },
                new Movie
                {
                    Name = "Ghostbusters ",
                    Genre = "Comedy",
                    Price = 32.99M,
                    ReleaseDate = DateTime.Parse("1984-3-13"),
                    Actors = "Bill Murray, Dan Aykroyd, Sigourney Weaver",
                    Description = "Three parapsychologists forced out of their university funding set up shop as a unique ghost removal service in New York City, attracting frightened yet skeptical customers.",
                    ImageUri = "https://placehold.co/100x100"
                },
                new Movie
                {
                    Name = "Ghostbusters 2",
                    Genre = "Comedy",
                    Price = 16.99M,
                    ReleaseDate = DateTime.Parse("1986-2-23"),
                    Actors = "Bill Murray, Dan Aykroyd, Sigourney Weaver",
                    Description = "The discovery of a massive river of ectoplasm and a resurgence of spectral activity allows the staff of Ghostbusters to revive the business.",
                    ImageUri = "https://placehold.co/100x100"
                },
                new Movie
                {
                    Name = "Rio Bravo",
                    Genre = "Western",
                    Price = 25.99M,
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    Actors = "John Wayne, Dean Martin, Ricky Nelson",
                    Description = "A small-town sheriff in the American West enlists the help of a disabled man, a drunk, and a young gunfighter in his efforts to hold in jail the brother of the local bad guy.",
                    ImageUri = "https://placehold.co/100x100"
                }
            );
            context.SaveChanges();
        }
    }
}