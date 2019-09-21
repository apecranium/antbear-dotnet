using System.Collections.Generic;
using System.Threading.Tasks;

namespace Antbear.Services
{
  public interface IService<T>
  {
    Task<bool> Exists(int id);
    Task<List<T>> GetAll();
    Task<T> GetOne(int id);
    Task<T> Create(T obj);
    Task<T> Update(T obj);
    Task Delete(int id);
  }
}
