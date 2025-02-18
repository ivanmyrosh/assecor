using AutoMapper;

using BusinessDTO;
using Domain.Core;
using Domain.Interface;

using Interfaces;

namespace Services
{
    public class PersonService:IPersonService
    {
        IUnitOfWork Database { get; set; }
        private Mapper mapperToDto;
        public PersonService(IUnitOfWork uow)
        {
            Database = uow;

            var configToDto = new MapperConfiguration(cfg => cfg.CreateMap<Person, PersonDTO>()
                .ForMember("Color", opt => opt.MapFrom(src => src.Color.Farbe)));
            mapperToDto = new Mapper(configToDto);
        }

        public PersonDTO? GetPerson(int? id)
        {
            
            if (id == null)
                return null;
            else
            {
                var result = Database.Persons.Get(id.GetValueOrDefault());
                return mapperToDto.Map<PersonDTO>(result);
            }

        }

        public IEnumerable<PersonDTO> GetPersons()
        {
            var result = Database.Persons.GetAll();
            return mapperToDto.Map<IEnumerable<PersonDTO>>(result);
        }

        public bool AddPerson(PersonDTO personDto)
        {
            var color = Database.Colors.GetAll()
                .FirstOrDefault(x => x.Farbe.ToLower().Equals(personDto.Color.ToLower()));
            if (color == null)
                return false;

            var maxId = Database.Persons.GetAll().Max(x => x.Id);

            var person = new Person()
            {
                Id = maxId + 1,
                City = personDto.City,
                Name = personDto.Name,
                LastName = personDto.LastName,
                ZipCode = personDto.ZipCode,
                Color = color,
            };

            Database.Persons.Add(person);

            return true;
        }
    }
}
