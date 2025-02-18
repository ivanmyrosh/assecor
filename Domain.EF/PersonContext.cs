using Domain.Core;
using Domain.Interface;

using Microsoft.EntityFrameworkCore;

namespace Domain.EF
{
    public class PersonContext : DbContext
    {
        public List<Person> Persons { get; set; } = new List<Person>();
        public List<Color> Colors { get; set; } = new List<Color>();

        public PersonContext(IReadPersonFromFile readPersonFromFile, IReadColor readColors)
        {
            Colors.AddRange(readColors.ReadColors());
            Persons.AddRange(readPersonFromFile.ReadPersons());
        }
    }
}
