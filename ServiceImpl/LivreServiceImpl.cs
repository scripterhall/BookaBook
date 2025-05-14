using BookaBook.Data;
using BookaBook.Models;
using BookaBook.Service;

namespace BookaBook.ServiceImpl
{
    public class LivreServiceImpl : LivreService
    {
        private readonly ApplicationDbContext _context;

        public LivreServiceImpl(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Livre> getAllLivre()
        {
            return _context.Livres.ToList();
        }
    }
}
