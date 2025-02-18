using BusinessDTO;

namespace Interfaces
{
    public interface IPersonService
    {
        PersonDTO? GetPerson(int? id);
        IEnumerable<PersonDTO> GetPersons();

    }
}
