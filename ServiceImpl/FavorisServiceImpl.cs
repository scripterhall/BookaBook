using BookaBook.Data;
using BookaBook.Models;
using BookaBook.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookaBook.ServiceImpl
{
    public class FavorisServiceImpl : FavorisService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public FavorisServiceImpl(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public void AddFavoris(Favoris favoris)
        {
            //add favoris to database
            _context.Favoris.Add(favoris);
            _context.SaveChanges();
        }

        public IEnumerable<Favoris> GetAllFavorisByNote(int note)
        {
            throw new NotImplementedException();
        }

        public Favoris GetFavorisById(Guid id)
        {
            return _context.Favoris.Include(f => f.Livre).FirstOrDefault(f => f.Id == id);
        }

        public IEnumerable<Favoris> GetAllFavorisByUserId()
        {
            // Get current user
            var user = _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User).Result;

            // Get all favoris by user id
            var favoris = _context.Favoris.Where(f => f.UserId == user.Id).Include(f => f.Livre).ToList();
            return favoris;
        }

        public void RemoveFavoris(Guid id)
        {
            //remove from favorite
            var fav = _context.Favoris.Find(id);
            if (fav != null)
            {
                _context.Favoris.Remove(fav);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Favoris> GetFavorisOrderedByTitleAsc()
        {
            return _context.Favoris
                      .OrderBy(f => f.Livre.Titre)
                      .Include(f => f.Livre)
                      .Include(f => f.Livre.Categorie)
            .ToList();
        }

        public IEnumerable<Favoris> GetFavorisOrderedByTitleDesc()
        {
            return _context.Favoris
                           .OrderByDescending(f => f.Livre.Titre)
                           .Include(f => f.Livre)
                           .Include(f => f.Livre.Categorie)
                           .ToList();
        }
        public IEnumerable<Favoris> GetFavorisByGenreName(string catName)
        {
            return _context.Favoris
                           .Where(f => f.Livre.Categorie.Nom == catName)
                           .Include(f => f.Livre)
                           .Include(f=> f.Livre.Categorie)
                           .ToList();
        }
    }
  
}
