using Domain.Core;
using Domain.Interface;

using Interfaces;

namespace Services
{
    public class ColorService: IColorService
    {
        IUnitOfWork Database { get; set; }

        public ColorService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public Color? GetColor(int? id)
        {
            if (id == null)
                return null;
            else
            {
                return Database.Colors.Get(id.GetValueOrDefault());
            }
        }

        public IEnumerable<Color> GetColors()
        {
            return Database.Colors.GetAll();
        }
    }
}
