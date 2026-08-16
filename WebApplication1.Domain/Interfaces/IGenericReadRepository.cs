namespace WebApplication1.Domain.Interfaces
{
    public interface IGenericReadRepository<T> where T : class
    {
        List<T> GetAll();
        T? GetById(int id);
    }
}
