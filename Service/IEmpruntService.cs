using BookaBook.Models;

namespace BookaBook.Service
{

    public interface IEmpruntService
    {
        Task BorrowAsync(Guid livreId, DateTime dateRetourPrevue);
        Task ReturnAsync(Guid empruntId);
        Task<IEnumerable<Emprunt>> GetActiveEmpruntsForUserAsync();
        Task BorrowMultipleAsync(IEnumerable<Guid> livreIds, DateTime dateRetourPrevue);
        Task<IEnumerable<Emprunt>> GetAllEmpruntsAsync();
    }
}
