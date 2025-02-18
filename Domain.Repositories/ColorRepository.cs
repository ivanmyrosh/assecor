using Domain.Core;
using Domain.EF;
using Domain.Interface;

namespace Domain.Repositories
{
    public class ColorRepository : IRepository<Color>
    {
        private PersonContext db;

        public ColorRepository(PersonContext context)
        {
            this.db = context;
        }
        public IEnumerable<Color> GetAll()
        {
            return db.Colors.ToList();
        }

        public Color Get(int id)
        {
            return db.Colors.FirstOrDefault(x => x.Id == id);
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
