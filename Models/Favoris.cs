using System.ComponentModel.DataAnnotations;

namespace BookaBook.Models
{
    public class Favoris : UserAction
    {
        [Range(1, 5)]
        public int? NoteUtilisateur { get; set; }
        public string? Commentaire { get; set; }

    }
    
}
