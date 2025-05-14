using BookaBook.Models;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace BookaBook.Service
{
    public interface FavorisService
    {
        Favoris GetFavorisById(Guid id);
        void AddFavoris(Favoris favoris);
         void RemoveFavoris(Guid id);
        IEnumerable<Favoris> GetAllFavorisByUserId();

        IEnumerable<Favoris> GetAllFavorisByNote(int note);
        IEnumerable<Favoris> GetFavorisOrderedByTitleAsc();
        IEnumerable<Favoris> GetFavorisOrderedByTitleDesc();
        IEnumerable<Favoris> GetFavorisByGenreName(string catName);

    }
}
