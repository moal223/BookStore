using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repository.SqlServer
{
    public class CategoryRepo : ICategoryRepo
    {
        AppDbContext _context;
        public CategoryRepo(AppDbContext ctx)
        {
            _context = ctx;
        }

        public int Add(Category model)
        {
            if (_context.categories?.Add(model) != null)
            {
                _context.SaveChanges();
                return 1;
            }
            return 0;

        }

        public async Task<int> AddAsync(Category model)
        {
            if (await _context.categories.AddAsync(model) != null)
            {
                await _context.SaveChangesAsync();
                return 1;
            }
            return 0;

        }
        public int Delete(Category model)
        {
            if (_context.categories.Remove(model) != null)
            {
                _context.SaveChanges();
                return 1;
            }
            return 0;
        }

        public async Task<int> DeleteAsync(Category model)
        {
            if (await Task.Run(() => Delete(model)) != 0)
            {
                await _context.SaveChangesAsync();
                return 1;
            }
            return 0;
        }

        public Category Find(int id)
        {
            return _context.categories.FirstOrDefault(b => b.Id == id);
        }

        public Task<Category> FindAsync(int id)
        {
            return _context.categories.FirstOrDefaultAsync(b => b.Id == id);
        }


        public IList<Category> GetAll()
        {
            return _context.categories.ToList();
        }

        public async Task<IList<Category>> GetAllAsync()
        {
            return await Task.Run(() => GetAll());
        }

        public int Update(Category model)
        {
            if (_context.categories.Update(model) != null)
            {
                _context.SaveChanges();
                return 1;
            }
            return 0;
        }

        public async Task<int> UpdateAsync(Category model)
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
