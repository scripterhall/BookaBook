using BookaBook.Data;
using BookaBook.Models;
using BookaBook.Service;
using Microsoft.EntityFrameworkCore;

namespace BookaBook.ServiceImpl
{
    public class LivreServiceImpl : ILivreService
    {
        private readonly ApplicationDbContext _context;

        public LivreServiceImpl(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Livre>> GetAllAsync()
        {
            return await _context.Livres.Include(l => l.Categorie).Include(l => l.Emprunts).ToListAsync();
        }

        public async Task<Livre?> GetByIdAsync(Guid id)
        {
            return await _context.Livres.Include(l => l.Categorie).Include(l => l.Emprunts).FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task CreateAsync(Livre livre)
        {
            livre.Id = Guid.NewGuid();
            _context.Livres.Add(livre);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Livre livre)
        {
            _context.Livres.Update(livre);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var livre = await _context.Livres.FindAsync(id);
            if (livre != null)
            {
                _context.Livres.Remove(livre);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Livre>> SearchAsync(string? titre, string? isbn, string? auteur, Guid? categorieId, string? langue)
        {
            var query = _context.Livres
                .Include(l => l.Categorie)
                .Include(l => l.Emprunts)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(titre))
                query = query.Where(l => l.Titre!.Contains(titre));

            if (!string.IsNullOrWhiteSpace(isbn))
                query = query.Where(l => l.ISBN!.Contains(isbn));

            if (!string.IsNullOrWhiteSpace(auteur))
                query = query.Where(l => l.Auteur!.Contains(auteur));

            if (categorieId.HasValue)
                query = query.Where(l => l.CategorieId == categorieId);

            if (!string.IsNullOrWhiteSpace(langue))
                query = query.Where(l => l.Langue!.Contains(langue));

            return await query.ToListAsync();
        }

        public async Task<(IEnumerable<Livre> Livres, int TotalCount)> SearchAndPaginateAsync(
    string? titre, string? isbn, string? auteur, Guid? categorieId, string? langue,
    string? sortField, string? sortOrder,
    int page, int pageSize)
        {
            var query = _context.Livres.Include(l => l.Categorie).Include(l => l.Emprunts).AsQueryable();

            if (!string.IsNullOrWhiteSpace(titre))
                query = query.Where(l => l.Titre != null && l.Titre.ToLower().Contains(titre.ToLower()));
            if (!string.IsNullOrWhiteSpace(isbn))
                query = query.Where(l => l.ISBN!.Contains(isbn));
            if (!string.IsNullOrWhiteSpace(auteur))
                query = query.Where(l => l.Auteur!.Contains(auteur));
            if (categorieId.HasValue)
                query = query.Where(l => l.CategorieId == categorieId);
            if (!string.IsNullOrWhiteSpace(langue))
                query = query.Where(l => l.Langue!.Contains(langue));

            // Sorting
            query = (sortField, sortOrder) switch
            {
                ("Titre", "asc") => query.OrderBy(l => l.Titre),
                ("Titre", "desc") => query.OrderByDescending(l => l.Titre),
                ("Auteur", "asc") => query.OrderBy(l => l.Auteur),
                ("Auteur", "desc") => query.OrderByDescending(l => l.Auteur),
                _ => query.OrderBy(l => l.Titre) // default
            };

            int totalCount = await query.CountAsync();

            var livres = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (livres, totalCount);
        }

    }
}
