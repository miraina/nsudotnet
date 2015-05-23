using System;
using System.Drawing;

namespace Milovanova.Nsudotnet.Perlin
{
    class Perlin
    {
        static void Main(string[] args)
        {
            int size = Convert.ToInt32(args[0]);
            Grid grid1 = new Grid(size, size, 2);
            Grid grid2 = new Grid(size, size, 4);
            Grid grid3 = new Grid(size, size, 8);
            Bitmap image = new Bitmap(size, size);

            double a = 0.3;
            double b = 0.3;
            double c = 0.3;
            
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    int red = (int)Math.Floor(a * grid1.GetColor(i, j).GetRed() + b * grid2.GetColor(i, j).GetRed() + c * grid3.GetColor(i, j).GetRed());
                    int blue = (int)Math.Floor(a * grid1.GetColor(i, j).GetBlue() + b * grid2.GetColor(i, j).GetBlue() + c * grid3.GetColor(i, j).GetBlue());
                    int green = (int)Math.Floor(a * grid1.GetColor(i, j).GetGreen() + b * grid2.GetColor(i, j).GetGreen() + c * grid3.GetColor(i, j).GetGreen());
                    
                    image.SetPixel(i, j, Color.FromArgb(red, green, blue));
                }
            }
            image.Save(args[1]);
        }
    }
}
