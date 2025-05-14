using BookaBook.Models;

namespace BookaBook.Service
{
    public interface LivreService
    {
        IEnumerable<Livre> getAllLivre();
    }
}
