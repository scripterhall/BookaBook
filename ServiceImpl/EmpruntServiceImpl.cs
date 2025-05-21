using BookaBook.Data;
using BookaBook.Models;
using BookaBook.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookaBook.ServiceImpl
{
    public class EmpruntServiceImpl : IEmpruntService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public EmpruntServiceImpl(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        // emprunter un livre
        public async Task BorrowAsync(Guid livreId, DateTime dateRetourPrevue)
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
                UserId = this.GetUserId(),
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

        public async Task<IEnumerable<Emprunt>> GetActiveEmpruntsForUserAsync()
        {
            return await _context.Emprunts
                .Include(e => e.Livre)
                .Where(e => e.UserId == this.GetUserId() && e.DateRetourEffective == null)
                .OrderBy(e => e.Etat)
                .ThenBy(e => e.DateRetourPrevue)
                .ToListAsync();
        }

        public async Task BorrowMultipleAsync()
        {
            var userId = this.GetUserId();

            var empruntsEnAttente = await _context.Emprunts
                .Where(e => e.UserId == userId && e.Etat == "En attente")
                .ToListAsync();

            if (!empruntsEnAttente.Any())
                throw new InvalidOperationException("Aucun emprunt en attente à valider.");

            foreach (var emprunt in empruntsEnAttente)
            {
                emprunt.Etat = "Validé";
                emprunt.DateAction = DateTime.Now;
            }

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Emprunt>> GetAllEmpruntsAsync()
        {
            try
            {
                return await _context.Emprunts
              .Include(e => e.Livre)
              .Include(e => e.User)
              .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erreur lors de la récupération des emprunts.", ex);
            }
        }

        public async Task AddToCartAsync(Guid livreId)
        {
            var livre = await _context.Livres
                .Include(l => l.Emprunts)
                .FirstOrDefaultAsync(l => l.Id == livreId);

            if (livre == null)
                throw new InvalidOperationException("Livre introuvable.");

            if (livre.NombreExemplairesDisponibles <= 0)
                throw new InvalidOperationException("Aucun exemplaire disponible.");

            var userId = this.GetUserId();

            bool alreadyInCart = await _context.Emprunts
                .AnyAsync(e => e.LivreId == livreId && e.UserId == userId && e.Etat == "En attente");

            if (alreadyInCart)
                throw new InvalidOperationException("Ce livre est déjà dans le panier.");


            var emprunt = new Emprunt
            {
                LivreId = livreId,
                UserId = userId,
                DateAction = DateTime.Now,
                Etat = "En attente"
            };

            _context.Emprunts.Add(emprunt);
            await _context.SaveChangesAsync();
        }

        // etat en attente cad les livre deja emprunté
        public async Task<IEnumerable<Emprunt>> GetCartAsync()
        {
            return await _context.Emprunts
                .Include(e => e.Livre)
                .Where(e => e.UserId == this.GetUserId() && e.Etat == "En attente")
                .ToListAsync();
        }


        public async Task RemoveFromCartAsync(Guid empruntId)
        {
            var emprunt = await _context.Emprunts
            .FirstOrDefaultAsync(e => e.Id == empruntId && e.UserId == this.GetUserId() && e.Etat == "En attente");

            if (emprunt == null)
                throw new InvalidOperationException("Emprunt introuvable dans le panier.");

            _context.Emprunts.Remove(emprunt);
            await _context.SaveChangesAsync();
        }

        private string GetUserId()
        {
            if (_httpContextAccessor.HttpContext == null || _httpContextAccessor.HttpContext.User == null)
                throw new InvalidOperationException("Contexte HTTP ou utilisateur introuvable.");

            var user = _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User).Result;
            if (user == null)
                throw new InvalidOperationException("Utilisateur introuvable.");

            return user.Id;
        }


    };




}