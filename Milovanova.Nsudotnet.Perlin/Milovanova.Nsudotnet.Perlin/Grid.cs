using System;
using System.Drawing;

namespace Milovanova.Nsudotnet.Perlin
{
    public class Grid
    {
        private int _dx;
        private int _dy;
        private int _order;
        private ColorRGB[,] _values;

        public Grid(int width, int height, int order)
        {
            _order = order + 2;
            _dx = width / order;
            _dy = height / order;
            _values = new ColorRGB[_order, _order];

            SetRandomValues();
        }

        private void SetRandomValues()
        {
            Random random = new Random();
            for (int i = 0; i < _order; i++)
            {
                for (int j = 0; j < _order; j++)
                {
                    _values[i, j] = new ColorRGB(random.Next(50, 255), random.Next(50, 255), random.Next(50, 255));
                }
            }
        }

        public ColorRGB GetColor(int x, int y)
        {
            int iX = (int)Math.Floor((double)x / _dx);
            int iY = (int)Math.Floor((double)y / _dy);
            if (iX >= _order - 1 || iY >= _order - 1)
            {
                return new ColorRGB(0,0,0);
            }

            double x1 = (iX) * _dx;
            double x2 = (iX + 1) * _dx;
            double y1 = (iY) * _dy;
            double y2 = (iY + 1) * _dy;

            ColorRGB f1 = (x2 - x) / (x2 - x1) * _values[iX, iY] + (x - x1) / (x2 - x1) * _values[iX + 1, iY];
            ColorRGB f2 = (x2 - x) / (x2 - x1) * _values[iX, iY + 1] + (x - x1) / (x2 - x1) * _values[iX + 1, iY + 1];
            ColorRGB resColor = (y2 - y) / (y2 - y1) * f1 + (y - y1) / (y2 - y1) * f2;

            return resColor;
        }
    }
}
