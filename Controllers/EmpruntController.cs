using BookaBook.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookaBook.Controllers
{
    public class EmpruntController(IEmpruntService empruntService) : Controller
    {
        private readonly IEmpruntService _empruntService = empruntService;

        // get pending emprunts
        public ActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Borrow(Guid livreId, DateTime dateRetourPrevue)
        {
            try
            {
                var userId = "826355f4-1030-4517-8b38-42d9118ad796";
                await _empruntService.BorrowAsync(livreId, userId, dateRetourPrevue);
                return RedirectToAction("Index", "Livres");
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return RedirectToAction("Details", "Livres", new { id = livreId });
            }
        }

        public async Task<IActionResult> MyEmprunts()
        {
            var userId = "826355f4-1030-4517-8b38-42d9118ad796";
            var emprunts = await _empruntService.GetActiveEmpruntsForUserAsync(userId);
            return View("Index", emprunts);
        }

        [HttpPost]
        public async Task<IActionResult> Return(Guid empruntId)
        {
            await _empruntService.ReturnAsync(empruntId);
            return RedirectToAction("MyEmprunts");
        }

    }
}