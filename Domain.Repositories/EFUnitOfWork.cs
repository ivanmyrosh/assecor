using Domain.Core;
using Domain.EF;
using Domain.Interface;

namespace Domain.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private PersonContext db;
        private PersonRepository personRepo;
        private ColorRepository colorRepo;

        public EFUnitOfWork(IReadPersonFromFile readPersonFromFile, IReadColor readColor)
        {
            db = new PersonContext(readPersonFromFile, readColor);
        }

        public IRepository<Person> Persons
        {
            get
            {
                if (personRepo == null)
                    personRepo = new PersonRepository(db);
                return personRepo;
            }
        }

        public IRepository<Color> Colors
        {
            get
            {
                if (colorRepo == null)
                    colorRepo = new ColorRepository(db);
                return colorRepo;
            }
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

                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

        }
    }
}
