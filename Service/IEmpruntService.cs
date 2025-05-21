using BookaBook.Models;

namespace BookaBook.Service
{

    public interface IEmpruntService
    {
        Task BorrowAsync(Guid livreId, DateTime dateRetourPrevue);
        Task ReturnAsync(Guid empruntId);
        Task<IEnumerable<Emprunt>> GetAllEmpruntsForCurrentUserAsync();
        Task BorrowMultipleAsync();
        Task<IEnumerable<Emprunt>> GetAllEmpruntsAsync();

        Task AddToCartAsync(Guid livreId, DateTime dateRetourPrevue);
        Task<IEnumerable<Emprunt>> GetCartAsync();

        Task RemoveFromCartAsync(Guid empruntId);
    }
}
