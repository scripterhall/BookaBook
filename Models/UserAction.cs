using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookaBook.Models
{

    /**
     * @class UserAction
     * @brief Classe abstraite représentant une action utilisateur.
     * 
     * Cette classe sert de base pour les actions effectuées par un utilisateur,
     * telles que l'emprunt ou le retour de livres. Elle contient des propriétés
     * communes à toutes les actions utilisateur.
     * casse des loop
     */
    public abstract class UserAction
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [ForeignKey("Livre")]
        public Guid? LivreId { get; set; }

        public Livre? Livre { get; set; } 

        [ForeignKey("ApplicationUser")]
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }
        public DateTime DateAction { get; set; } = DateTime.Now;

    }
}
