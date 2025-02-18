using Domain.Core;

namespace Domain.Interface
{
    public interface IReadPersonFromFile
    {
        IEnumerable<Person> ReadPersons();
    }
}
