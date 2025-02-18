using Domain.Core;

namespace Domain.Interface
{
    public interface IRepository<T> : IDisposable where T: class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
    }
}
