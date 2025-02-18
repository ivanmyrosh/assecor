using Domain.Core;

namespace Interfaces
{
    public interface IColorService
    {
        Color GetColor(int? id);
        IEnumerable<Color> GetColors();
    }
}
