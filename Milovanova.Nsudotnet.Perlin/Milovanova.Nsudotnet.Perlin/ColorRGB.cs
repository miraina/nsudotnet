

namespace Milovanova.Nsudotnet.Perlin
{
    public class ColorRGB
    {
        private int _red;
        private int _green;
        private int _blue;

        public int GetRed()
        {
            return _red;
        }

        public int GetBlue()
        {
            return _blue;
        }

        public int GetGreen()
        {
            return _green;
        }

        public ColorRGB(int red, int green, int blue)
        {
            _red = red;
            _green = green;
            _blue = blue;
        }

        public static ColorRGB operator *(double k, ColorRGB color)
        {
            return new ColorRGB((int)(color._red * k), (int)(color._green * k), (int)(color._blue * k));
        }

        public static ColorRGB operator +(ColorRGB color1, ColorRGB color2)
        {
            return new ColorRGB(color1._red + color2._red, color1._green + color2._green, color1._blue + color2._blue);
        }

    }
}
