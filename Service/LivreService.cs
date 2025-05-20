using BookaBook.Models;

namespace BookaBook.Service
{
    public interface ILivreService
    {
        Task<IEnumerable<Livre>> GetAllAsync();
        Task<Livre?> GetByIdAsync(Guid id);
        Task CreateAsync(Livre livre);
        Task UpdateAsync(Livre livre);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<Livre>> SearchAsync(string? titre, string? isbn, string? auteur, Guid? categorieId, string? langue);
        Task<(IEnumerable<Livre> Livres, int TotalCount)> SearchAndPaginateAsync(string? titre, string? isbn, string? auteur, Guid? categorieId, string? langue,string? sortField, string? sortOrder,int page, int pageSize);
    }
}
