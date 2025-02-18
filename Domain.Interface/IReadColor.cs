using Domain.Core;

namespace Domain.Interface
{
    public interface IReadColor
    {
        IEnumerable<Color> ReadColors();
    }
}
