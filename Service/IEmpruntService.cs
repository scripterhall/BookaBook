using BookaBook.Models;

namespace BookaBook.Service
{

    public interface IEmpruntService
    {
        Task BorrowAsync(Guid livreId, string userId, DateTime dateRetourPrevue);
        Task ReturnAsync(Guid empruntId);
        Task<IEnumerable<Emprunt>> GetActiveEmpruntsForUserAsync(string userId);
        Task BorrowMultipleAsync(IEnumerable<Guid> livreIds,string userId, DateTime dateRetourPrevue);
    }
}
