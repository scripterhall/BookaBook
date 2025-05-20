using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookaBook.Models
{
    public class Livre
    {

        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public string? Titre { get; set; }

        public string? ISBN { get; set; } = String.Empty;

        public string? Auteur { get; set; }
        public string? Description { get; set; } = String.Empty; 
        public int? AnneePublication { get; set; }
        public string? ImageUrl { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; } // uploaded file

        public Guid? CategorieId { get; set; }
        public Category? Categorie { get; set; }

        public int NombreExemplaires { get; set; }

        public string? Langue { get; set; }

        
    }
}
