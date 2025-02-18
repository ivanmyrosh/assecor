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
        private Mapper mapper;

        public PersonService(IUnitOfWork uow)
        {
            Database = uow;

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Person, PersonDTO>()
                .ForMember("Color", opt => opt.MapFrom(src => src.Color.Farbe)));
            mapper = new Mapper(config);

        }

        public PersonDTO? GetPerson(int? id)
        {
            
            if (id == null)
                return null;
            else
            {
                var result = Database.Persons.Get(id.GetValueOrDefault());
                return mapper.Map<PersonDTO>(result);
            }

        }

        public IEnumerable<PersonDTO> GetPersons()
        {
            var result = Database.Persons.GetAll();
            return mapper.Map<IEnumerable<PersonDTO>>(result);
        }
    }
}
