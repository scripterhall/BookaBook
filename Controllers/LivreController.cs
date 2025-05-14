using BookaBook.Service;
using Microsoft.AspNetCore.Mvc;

namespace BookaBook.Controllers
{
    public class LivreController : Controller
    {
        private readonly LivreService _livreService;
        private readonly FavorisService _favorisService;

        public LivreController(LivreService livreService,FavorisService favorisService)
        {
            _livreService = livreService;
            _favorisService = favorisService;
        }

        public IActionResult Index()
        {
            /**
             * ca fonctione que pour le current user sinon n'affiche pas 
             */
            var livres = _livreService.getAllLivre();
            var favoris = _favorisService.GetAllFavorisByUserId();
            var booksWithFavourite = new ModelView.BooksWithFavourite(livres, favoris);
            return View(booksWithFavourite);
        }
    }
}
