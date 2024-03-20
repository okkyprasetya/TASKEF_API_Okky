using System.Collections.Generic;

namespace MyRESTServices.Data.Interfaces
{
    public interface ICrudData<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<Task> Insert(T entity);
        Task<Task> Update(T entity);
        Task<bool> Delete(int id);
    }
}
