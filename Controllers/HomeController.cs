using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BookaBook.Models;
using Microsoft.EntityFrameworkCore;
using BookaBook.Data;
using BookaBook.ModelView;

namespace BookaBook.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        //Get best livres
        var favorisGroupes = await _context.Favoris
            .Where(f => f.LivreId != null)
            .GroupBy(f => f.LivreId)
            .Select(g => new
            {
                LivreId = g.Key,
                NombreFavoris = g.Count(),
                NoteMoyenne = g.Average(f => f.NoteUtilisateur ?? 0)
            })
            .OrderByDescending(g => g.NombreFavoris)
            .Take(6)
            .ToListAsync();

        var livres = await _context.Livres
            .Where(l => favorisGroupes.Select(f => f.LivreId).Contains(l.Id))
            .ToListAsync();

        var topLivreId = favorisGroupes.FirstOrDefault()?.LivreId;

        var livresAvecInfos = livres.Select(l => new LivreFavorisModelView
        {
            Livre = l,
            NoteMoyenne = Math.Round(favorisGroupes.FirstOrDefault(f => f.LivreId == l.Id)?.NoteMoyenne ?? 0, 1),
            IsTop1 = l.Id == topLivreId
        }).ToList();

        return View(livresAvecInfos);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
