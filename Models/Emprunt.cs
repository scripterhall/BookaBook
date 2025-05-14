using System.ComponentModel.DataAnnotations;

namespace BookaBook.Models
{
    public class Emprunt : UserAction
    {
        [Required]
        public DateTime DateRetourPrevue { get; set; }
        public DateTime? DateRetourEffective { get; set; }
        
        public String etat { get; set; } = "Validé";


    }
}
