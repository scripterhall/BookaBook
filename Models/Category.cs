using System.ComponentModel.DataAnnotations;

namespace BookaBook.Models
{
    public class Category
    {
        [Required]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Nom { get; set; }
        public string? Description { get; set; }
        public ICollection<Livre> Livres { get; set; } = new List<Livre>();
    }




































}
