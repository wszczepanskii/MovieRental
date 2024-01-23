using Microsoft.AspNetCore.Identity;

namespace MovieRental.Models;

public class AppUser : IdentityUser
{
    public string? AppUserName { get; set; }
}
