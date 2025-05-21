using System.ComponentModel.DataAnnotations;

namespace BookaBook.Models
{
    public class Emprunt : UserAction
    {
        [Required]
        public DateTime DateRetourPrevue { get; set; }
        public DateTime? DateRetourEffective { get; set; }
        
        public String Etat { get; set; } = "Validé"; // Validé, EnAttente, Retardé, Annulé

    
    }
}
