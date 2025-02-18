using Domain.Core;
using Domain.EF;
using Domain.Interface;

namespace Infrastructure.Data
{
    public class PersonRepository : IRepository<Person>
    {
        private PersonContext db;

        public PersonRepository(PersonContext context)
        {
            this.db = context;
        }

        public IEnumerable<Person> GetAll()
        {
            return db.Persons.ToList();
        }

        public Person Get(int id)
        {
            return db.Persons.FirstOrDefault(x => x.Id == id);
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
