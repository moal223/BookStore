using BookStore.Models;

namespace BookStore.Repository.SqlServer
{
    public interface IBookRepo : IDataHelper<Book>
    {
        IList<Book> FindWithCategory(string category);
        Task<IList<Book>> FindWithCategoryAsync(string category);
    }
}
