using Domain.Core;

namespace Domain.Data
{
    public static class Colors
    {
        public static IEnumerable<Color> ExistedColors = new List<Color>
        {
            new Color { Id = 1, Farbe = "blau" },
            new Color { Id = 2, Farbe = "grün" },
            new Color { Id = 3, Farbe = "violett" },
            new Color { Id = 4, Farbe = "rot" },
            new Color { Id = 5, Farbe = "gelb" },
            new Color { Id = 6, Farbe = "türkis" },
            new Color { Id = 7, Farbe = "weiß" },

        };
    }
}
