using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.InteropServices;

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
            SolidBrush colorToFind = new SolidBrush(Color.FromArgb(255, 200, 193, 189));
            while (true)
            {
                IntPtr hDC = GetDC(IntPtr.Zero);
                uint pixelu = GetPixel(hDC, 495, 465);
                uint pixel = GetPixel(hDC, 495, 465);
                ReleaseDC(IntPtr.Zero, hDC);
                byte r = (byte)(pixel & 0x000000FF);
                byte g = (byte)((pixel & 0x0000FF00)  >> 8);
                byte b = (byte)((pixel & 0x00FF0000)  >> 16);
                SolidBrush color = new SolidBrush(Color.FromArgb(255, r, g, b));
                if (color == colorToFind) Keyboard.Нажать;
            }
        }
    }
}