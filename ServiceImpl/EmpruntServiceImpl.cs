using BookaBook.Data;
using BookaBook.Models;
using BookaBook.Service;
using Microsoft.EntityFrameworkCore;

namespace BookaBook.ServiceImpl
{
    public class EmpruntServiceImpl : IEmpruntService
    {
        private readonly ApplicationDbContext _context;

        public EmpruntServiceImpl(ApplicationDbContext context)
        {
            _context = context;
        }

        // emprunter un livre
        public async Task BorrowAsync(Guid livreId, string userId, DateTime dateRetourPrevue)
        {
            var livre = await _context.Livres
                .Include(l => l.Emprunts)
                .FirstOrDefaultAsync(l => l.Id == livreId);

            if (livre == null)
                throw new InvalidOperationException("Livre introuvable.");

            if (livre.NombreExemplairesDisponibles <= 0)
                throw new InvalidOperationException("Aucun exemplaire disponible.");

            var emprunt = new Emprunt
            {
                LivreId = livreId,
                UserId = userId,
                DateRetourPrevue = dateRetourPrevue,
                DateAction = DateTime.Now,
                Etat = "Validé"
            };

            _context.Emprunts.Add(emprunt);
            await _context.SaveChangesAsync();
        }

        // retourner un livre
        public async Task ReturnAsync(Guid empruntId)
        {
            var emprunt = await _context.Emprunts.FindAsync(empruntId);
            if (emprunt == null)
                throw new InvalidOperationException("Emprunt introuvable.");

            emprunt.DateRetourEffective = DateTime.Now;
            emprunt.Etat = emprunt.DateRetourEffective > emprunt.DateRetourPrevue
                           ? "En retard"
                           : "Terminé";

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Emprunt>> GetActiveEmpruntsForUserAsync(string userId)
        {
            return await _context.Emprunts
                .Include(e => e.Livre)
                .Where(e => e.UserId == userId && e.DateRetourEffective == null)
                .ToListAsync();
        }

        public async Task BorrowMultipleAsync(
    IEnumerable<Guid> livreIds,
    string userId,
    DateTime dateRetourPrevue)
        {
            var livres = await _context.Livres
                .Include(l => l.Emprunts)
                .Where(l => livreIds.Contains(l.Id))
                .ToListAsync();

            foreach (var livre in livres)
            {
                if (livre.NombreExemplairesDisponibles <= 0)
                    throw new InvalidOperationException(
                        $"Livre '{livre.Titre}' n'est pas disponible.");
            }

            var emprunts = livres.Select(livre => new Emprunt
            {
                LivreId = livre.Id,
                UserId = userId,
                DateRetourPrevue = dateRetourPrevue,
                DateAction = DateTime.Now,
                Etat = "Validé"
            });

            _context.Emprunts.AddRange(emprunts);
            await _context.SaveChangesAsync();
        }

    }
}