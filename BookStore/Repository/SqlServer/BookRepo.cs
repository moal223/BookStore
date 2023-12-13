using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repository.SqlServer
{
    public class BookRepo: IBookRepo
    {
        AppDbContext _context;
        public BookRepo(AppDbContext ctx)
        {
            _context = ctx;
        }

        public int Add(Book model)
        {
            if (_context.Books?.Add(model) != null)
            {
                _context.SaveChanges();
                return 1;
            }
            return 0;
            
        }

        public async Task<int> AddAsync(Book model)
        {
            if (await _context.Books.AddAsync(model) != null)
            {
                await _context.SaveChangesAsync();
                return 1;
            }
            return 0;
            
        }

        public int Delete(Book model)
        {
            if (_context.Books.Remove(model) != null)
            {
                _context.SaveChanges();
                return 1;
            }
            return 0;
        }

        public async Task<int> DeleteAsync(Book model)
        {
            if (await Task.Run(() => Delete(model)) != 0)
            {
                await _context.SaveChangesAsync();
                return 1;
            }
            return 0;
        }

        public Book Find(int id)
        {
            return _context.Books.FirstOrDefault(b => b.Id == id);
        }

        public Task<Book> FindAsync(int id)
        {
            return _context.Books.FirstOrDefaultAsync(b => b.Id == id);
        }

        public IList<Book> FindWithCategory(string category)
        {
            return _context.Books.Where(b => b.Category.Any(c => c.Name == category)).ToList();
        }

        public async Task<IList<Book>> FindWithCategoryAsync(string category)
        {
            return await Task.Run(() => FindWithCategory(category));
        }

        public IList<Book> GetAll()
        {
            return _context.Books.ToList();
        }

        public async Task<IList<Book>> GetAllAsync()
        {
            return await Task.Run(() => GetAll());
        }

        public int Update(Book model)
        {
            if(_context.Books.Update(model) != null)
            {
                _context.SaveChanges();
                return 1;
            }
            return 0;
        }


        public async Task<int> UpdateAsync(Book model)
        {
            if (await Task.Run(() => Update(model)) != 0)
            {
                await _context.SaveChangesAsync();
                return 1;
            }
            return 0;
        }
    }
}
