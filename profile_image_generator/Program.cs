using System;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        string firstName = Console.ReadLine();
        string lastName = Console.ReadLine();

        Color color = Color.FromArgb(100, Color.Gray);
        SolidBrush brush = new SolidBrush(color);
        Bitmap outputImage = new Bitmap(256, 256);

        Graphics graphics = Graphics.FromImage(outputImage);
        graphics.FillEllipse(brush, 0, 0, 256, 256);

        outputImage.Save("test.bmp");
        graphics.Dispose();
    }
}
