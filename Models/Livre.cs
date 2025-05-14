using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookaBook.Models
{
    public class Livre
    {

        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(100)]
        public string? Titre { get; set; }

        [Required]
        public string? ISBN { get; set; } = String.Empty;

        [Required]
        [StringLength(100)] 
        public string? Auteur { get; set; }
        [Required]
        [StringLength(100)]
        public string? Description { get; set; } = String.Empty; 
        public int? AnneePublication { get; set; }
        public string? ImageUrl { get; set; }

        [ForeignKey("Category")]
        public Guid? CategorieId { get; set; }
        public Category? Categorie { get; set; }

        [Required]
        public int NombreExemplaires { get; set; }

        [Required]
        public string? Langue { get; set; }

        
    }
}
