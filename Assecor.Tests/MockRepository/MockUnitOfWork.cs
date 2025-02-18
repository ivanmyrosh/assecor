using Domain.Core;
using Domain.EF;
using Domain.Interface;
using Domain.Repositories;

namespace Assecor.Tests.MockRepository
{

    public class MockUnitOfWork : IUnitOfWork
    {
        private PersonContext _context;
        private PersonRepository personRepo;
        private ColorRepository colorRepo;

        public MockUnitOfWork(PersonContext context)
        {
            _context = context;
        }

        public IRepository<Person> Persons
        {
            get
            {
                if (personRepo == null)
                    personRepo = new PersonRepository(_context);
                return personRepo;
            }
        }

        public IRepository<Color> Colors
        {
            get
            {
                if (colorRepo == null)
                    colorRepo = new ColorRepository(_context);
                return colorRepo;
            }
        }

        public void Dispose()
        {
        }
    }
}
