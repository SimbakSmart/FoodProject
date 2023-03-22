namespace API.Interfaces
{
    public interface IGenericRepository<T>
    {
        Task<T> CreatedAsync(T t);
        Task<T> EditAsync(T t,int? id);
        Task<T> DeletedAsync(int? id);
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<int> CountAsync();
    }
}
