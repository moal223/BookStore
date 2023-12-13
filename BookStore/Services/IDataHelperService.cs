namespace BookStore.Services
{
    public interface IDataHelperService<T>
    {
        IList<T> GetAll();
        T Find(int id);
        int Add(T model);
        int Update(T model);
        int Delete(T model);
        // Async Methods
        Task<IList<T>> GetAllAsync();
        Task<T> FindAsync(int id);

        Task<int> AddAsync(T model);
        Task<int> UpdateAsync(T model);
        Task<int> DeleteAsync(T model);
    }
}
