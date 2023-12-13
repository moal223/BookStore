using BookStore.Models;
using BookStore.Repository.SqlServer;

namespace BookStore.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepo? _categoryRepo;
        public CategoryService(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }
        public int Add(Category model)
        {
            return _categoryRepo.Add(model);
        }

        public async Task<int> AddAsync(Category model)
        {
            return await _categoryRepo.AddAsync(model);
        }

        public int Delete(Category model)
        {
            return _categoryRepo.Delete(model);
        }

        public async Task<int> DeleteAsync(Category model)
        {
            return await _categoryRepo.DeleteAsync(model);
        }

        public Category Find(int id)
        {
            return _categoryRepo.Find(id);
        }

        public async Task<Category> FindAsync(int id)
        {
            return await _categoryRepo.FindAsync(id);
        }

        public IList<Category> GetAll()
        {
            return _categoryRepo.GetAll().ToList();
        }

        public async Task<IList<Category>> GetAllAsync()
        {
            return await _categoryRepo.GetAllAsync();
        }

        public int Update(Category model)
        {
            return _categoryRepo.Update(model);
        }

        public async Task<int> UpdateAsync(Category model)
        {
            return await _categoryRepo.UpdateAsync(model);
        }
    }
}
