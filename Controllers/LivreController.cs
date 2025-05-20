using BookaBook.Models;
using BookaBook.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookaBook.Controllers
{
    public class LivreController : Controller
    {
        private readonly ILivreService _livreService;
        private readonly FavorisService _favorisService;
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _env;

        public LivreController(ILivreService livreService, FavorisService favorisService, ICategoryService categoryService, IWebHostEnvironment env)
        {
            _livreService = livreService;
            _favorisService = favorisService;
            _categoryService = categoryService;
            _env = env;
        }

        //public async Task<IActionResult> Index(string? searchTitre, string? searchISBN, string? searchAuteur, Guid? searchCategorieId, string? searchLangue)
        //{
        //    var livres = await _livreService.SearchAsync(searchTitre, searchISBN, searchAuteur, searchCategorieId, searchLangue);

        //    ViewBag.Categories = new SelectList(await _categoryService.GetAllAsync(), "Id", "Nom", searchCategorieId);

        //    return View(livres);
        //}

        public async Task<IActionResult> Index(string? searchTitre, string? searchISBN, string? searchAuteur,
            Guid? searchCategorieId, string? searchLangue,
            string? sortField = "Titre", string? sortOrder = "asc",
            int page = 1, int pageSize = 10) // default pageSize = 10
        {
            var (livres, totalCount) = await _livreService.SearchAndPaginateAsync(
                searchTitre, searchISBN, searchAuteur,
                searchCategorieId, searchLangue,
                sortField, sortOrder,
                page, pageSize);

            ViewBag.Categories = new SelectList(await _categoryService.GetAllAsync(), "Id", "Nom", searchCategorieId);
            ViewBag.SortField = sortField;
            ViewBag.SortOrder = sortOrder;
            ViewBag.Page = page;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            var favoris = _favorisService.GetAllFavorisByUserId();
            var booksWithFavourite = new ModelView.BooksWithFavourite(livres, favoris);
            return View(booksWithFavourite);
        }


        public async Task<IActionResult> Details(Guid id)
        {
            var livre = await _livreService.GetByIdAsync(id);
            if (livre == null) return NotFound();
            return View(livre);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = new SelectList(await _categoryService.GetAllAsync(), "Id", "Nom");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Livre livre)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = new SelectList(await _categoryService.GetAllAsync(), "Id", "Nom", livre.CategorieId);
                return View(livre);
            }

            // Handle file upload
            if (livre.ImageFile != null && livre.ImageFile.Length > 0)
            {
                var uploadsFolder = Path.Combine(_env.WebRootPath, "uploads");
                Directory.CreateDirectory(uploadsFolder); // ensure folder exists

                var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(livre.ImageFile.FileName);
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await livre.ImageFile.CopyToAsync(stream);
                }

                livre.ImageUrl = "/uploads/" + uniqueFileName;
            }

            await _livreService.CreateAsync(livre);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var livre = await _livreService.GetByIdAsync(id);
            if (livre == null) return NotFound();
            ViewBag.Categories = new SelectList(await _categoryService.GetAllAsync(), "Id", "Nom", livre.CategorieId);
            return View(livre);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Livre livre)
        {
            if (id != livre.Id) return NotFound();
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = new SelectList(await _categoryService.GetAllAsync(), "Id", "Nom", livre.CategorieId);
                return View(livre);
            }

            // Handle file upload
            if (livre.ImageFile != null && livre.ImageFile.Length > 0)
            {
                var uploadsFolder = Path.Combine(_env.WebRootPath, "uploads");
                Directory.CreateDirectory(uploadsFolder); // ensure folder exists

                var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(livre.ImageFile.FileName);
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await livre.ImageFile.CopyToAsync(stream);
                }

                livre.ImageUrl = "/uploads/" + uniqueFileName;
            }

            await _livreService.UpdateAsync(livre);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var livre = await _livreService.GetByIdAsync(id);
            if (livre == null) return NotFound();
            return View(livre);
        }

        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _livreService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
