using BookaBook.Models;
using Microsoft.AspNetCore.Identity;
using NuGet.Protocol;

namespace BookaBook.ModelView
{
    public class BooksWithFavourite
    {
        public IEnumerable<Livre>? Livres { get; set; }
        public IEnumerable<Favoris>? Favoris { get; set; }

        public Favoris? makeItFavourite { get; set; } = new Favoris();

        //private readonly UserManager<ApplicationUser> userManager;

        public BooksWithFavourite() { }

        public BooksWithFavourite(IEnumerable<Livre> livres,IEnumerable<Favoris> favoris)
        {
            Livres = livres;
            Favoris = favoris;
        }

        public bool isFavouriteForCurrentUser(Guid livreId)
        {
            /**
             * ne fonctionne que avec le current user
             */
            return Favoris.Any(f => f.Livre.Id == livreId  );
        }

        public Guid findFavorisForUser(Guid livreId, string userId)
        {
            // a regler avec current user
            Favoris? favoris = Favoris.FirstOrDefault(f => f.LivreId == livreId && f.UserId.Equals(userId));
            return favoris.Id;
        }
    }
}
