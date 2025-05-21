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

        public async Task<IActionResult> AllEmprunts()
        {
            var emprunts = await _empruntService.GetAllEmpruntsAsync();
            return View(emprunts);
        }

    }
}