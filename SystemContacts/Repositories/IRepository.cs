namespace SystemContacts.Repositories
{
    public interface IRepository<T>
    {
        T Add(T entity);
        List<T> GetAll();
        T? GetById(int id); 
        T Update(T entity);
        bool Delete(int id);  
    }
}
