using Microsoft.AspNetCore.Identity;

namespace BookaBook.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public ICollection<Emprunt> Emprunts { get; set; } = new List<Emprunt>();

    }
}
