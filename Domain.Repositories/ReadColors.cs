using Domain.Core;
using Domain.Interface;

namespace Domain.Repositories
{
    public class ReadColor: IReadColor
    {
        public IEnumerable<Color> ReadColors()
        {
            return Data.Colors.ExistedColors;
        }
    }
}
