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
                .ToListAsync();
        }

        public async Task BorrowMultipleAsync(IEnumerable<Guid> livreIds, DateTime dateRetourPrevue)
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
                UserId = this.GetUserId(),
                DateRetourPrevue = dateRetourPrevue,
                DateAction = DateTime.Now,
                Etat = "Validé"
            });

            _context.Emprunts.AddRange(emprunts);
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