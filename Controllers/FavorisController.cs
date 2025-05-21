using BookaBook.Models;
using BookaBook.ModelView;
using BookaBook.Service;
using Microsoft.AspNetCore.Mvc;

namespace BookaBook.Controllers
{
    public class FavorisController : Controller
    {
        private readonly FavorisService _favorisService;
        public FavorisController(FavorisService favorisService)
        {
            _favorisService = favorisService;
        }
        public IActionResult Index()
        {
            // Get all favoris by user id
            var favoris = _favorisService.GetAllFavorisByUserId();
            return View(favoris);
        }

        [HttpPost]
        public IActionResult Create(BooksWithFavourite bwf)
        {
            if (ModelState.IsValid)
            {
                _favorisService.AddFavoris(bwf.makeItFavourite!);
                
            }
            return RedirectToAction("Index", "Livre");
        }

        public IActionResult OrderedByTitle()
        {
            var favoris = _favorisService.GetFavorisOrderedByTitleAsc();
            return View("Index", favoris);
        }
        // Action to get movies ordered by title in ascending order
        public IActionResult OrderedByTitledesc()
        {
            var movies = _favorisService.GetFavorisOrderedByTitleDesc();
            return View("Index", movies);
        }

        public IActionResult ByGenreName(string catName)
        {
            var movies = _favorisService.GetFavorisByGenreName(catName);
            return View("Index", movies);
        }

        public IActionResult Delete(Guid id)
        {
            var favoris = _favorisService.GetFavorisById(id);
            if (favoris == null) return NotFound();
            return View(favoris);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var favoris = _favorisService.GetFavorisById(id);
            if (favoris == null) return NotFound();
            _favorisService.RemoveFavoris(id);
            return RedirectToAction("Index", "Livre"); // ou autre page après suppression
        }


    }
}
