using BookStore.Models;
using BookStore.Repository.SqlServer;

namespace BookStore.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepo _bookRepo;
        public BookService(IBookRepo bookRepo) {
            _bookRepo = bookRepo;
        }
        public int Add(Book model)
        {
            return _bookRepo.Add(model);
        }

        public async Task<int> AddAsync(Book model)
        {
            return await _bookRepo.AddAsync(model);
        }

        public int Delete(Book model)
        {
            return _bookRepo.Delete(model);
        }

        public async Task<int> DeleteAsync(Book model)
        {
            return await _bookRepo.DeleteAsync(model);
        }

        public Book Find(int id)
        {
            return _bookRepo.Find(id);
        }

        public async Task<Book> FindAsync(int id)
        {
            return await _bookRepo.FindAsync(id);
        }

        public IList<Book> FindWithCategory(string category)
        {
            return _bookRepo.FindWithCategory(category);
        }
        public async Task<IList<Book>> FindWithCategoryAsync(string category)
        {
            return await _bookRepo.FindWithCategoryAsync(category);
        }

        public IList<Book> GetAll()
        {
            return _bookRepo.GetAll().ToList();
        }

        public async Task<IList<Book>> GetAllAsync()
        {
            return await _bookRepo.GetAllAsync();
        }

        public int Update(Book model)
        {
            return _bookRepo.Update(model);
        }

        public async Task<int> UpdateAsync(Book model)
        {
            return await _bookRepo.UpdateAsync(model);
        }
    }
}
