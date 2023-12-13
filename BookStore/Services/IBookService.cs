using BookStore.Models;

namespace BookStore.Services
{
    public interface IBookService : IDataHelperService<Book>
    {
        IList<Book> FindWithCategory(string category);
        Task<IList<Book>> FindWithCategoryAsync(string category);
    }
}
