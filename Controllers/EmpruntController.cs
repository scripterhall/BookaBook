using BookaBook.Service;
using Microsoft.AspNetCore.Mvc;

namespace BookaBook.Controllers
{
    public class EmpruntController(IEmpruntService empruntService) : Controller
    {
        private readonly IEmpruntService _empruntService = empruntService;

        public async Task<IActionResult> Index()
        {

            var emprunts = await _empruntService.GetActiveEmpruntsForUserAsync();
            return View("Index", emprunts);
        }

        public async Task<IActionResult> Borrow(Guid livreId, DateTime dateRetourPrevue)
        {
            try
            {
                await _empruntService.BorrowAsync(livreId, dateRetourPrevue);
                return RedirectToAction("Index", "Livre");
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return RedirectToAction("Details", "Livre", new { id = livreId });
            }
        }


        [HttpPost]
        public async Task<IActionResult> Return(Guid empruntId)
        {
            await _empruntService.ReturnAsync(empruntId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(Guid livreId)
        {
            try
            {
                await _empruntService.AddToCartAsync(livreId);
                return RedirectToAction("Index", "Livre");
            }
            catch (InvalidOperationException ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Details", "Livre", new { id = livreId });
            }
        }

        public async Task<IActionResult> Cart()
        {
            var cart = await _empruntService.GetCartAsync();
            return View("Cart", cart);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(Guid empruntId)
        {
            await _empruntService.RemoveFromCartAsync(empruntId);
            return RedirectToAction("Cart");
        }

        [HttpPost]
        public async Task<IActionResult> BorrowMultiple()
        {
            try
            {
                await _empruntService.BorrowMultipleAsync();
                return RedirectToAction("Index");
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return RedirectToAction("Cart");
            }
        }



    }
}