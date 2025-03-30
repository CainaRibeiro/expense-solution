namespace ExpenseSolution.Repositories
{
    public interface IGenericRepository<T> where T: class
    {
        Task<T> Create(T entity);
        Task<T> GetById(int id);
        Task Delete(int id);
        Task<List<T>> GetAll();
    }
}
