namespace WebApplication1.Domain.Interfaces
{
    public interface IGenericWriteRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
