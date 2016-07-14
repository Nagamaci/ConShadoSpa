using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Threading;

namespace ConShadoSpa
{
    class Program
    {
        [DllImport("user32.dll")]
        public static extern IntPtr GetDC(IntPtr hwnd);

        [DllImport("user32.dll")]
        public static extern int ReleaseDC(IntPtr hwnd, IntPtr hDC);

        [DllImport("gdi32.dll")]
        public static extern uint GetPixel(IntPtr hDC, int x, int y);
        static void Main(string[] args)
        {
            Color colorToFind = Color.FromArgb(200, 193, 189);
            List<Point> points = new List<Point>()
{
new Point(495, 465),//Верх 
new Point(495, 605),//Низ 
new Point(425, 535),//Лево 
new Point(565, 535) //Право 
};
            while (true)
            {
                int L = points.Count;
                for (int i = 0; i < L; i++)
                {
                    IntPtr hDC = GetDC(IntPtr.Zero);
                    uint pixel = GetPixel(hDC, points[i].X, points[i].Y);
                    ReleaseDC(IntPtr.Zero, hDC);
                    byte r = (byte)(pixel & 0x000000FF);
                    byte g = (byte)((pixel & 0x0000FF00) >> 8);
                byte b = (byte)((pixel & 0x00FF0000) >> 16);
                Color color = Color.FromArgb(r, g, b);
                if (color == colorToFind)
                {
                        Console.WriteLine("HUI");
                    switch (i)
                    {
                        case 0:
                            SendKeys.SendWait("{UP}");
                            break;
                        case 1:
                            SendKeys.SendWait("{DOWN}");
                            break;
                        case 2:
                            SendKeys.SendWait("{LEFT}");
                            break;
                        case 3:
                            SendKeys.SendWait("{RIGHT}");
                            break;
                    }
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
}