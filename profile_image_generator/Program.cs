using System;
using System.Drawing;

class Program
{
    private const int OutputImageSize = 256;
    private const string OutputImageFilePath = "output.bmp";
    private static Random rnd = new Random();

    static string GetAbbreviation()
    {
        Console.Write("Please input your firstname: ");
        string firstName = Console.ReadLine();

        Console.Write("Please input your lastname: ");
        string lastName = Console.ReadLine();

        if(firstName == "" || lastName == "")
        {
            Console.WriteLine("Invalid firstname or lastname. Please try again.");
            return GetAbbreviation();
        }

        return String.Format("{0}{1}", firstName[0], lastName[0]);
    }

    static Color GetRandomColor()
    {
        return Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
    }

    static void Main(string[] args)
    {
        string abbreviation = GetAbbreviation();

        //  Prepare drawing assets.
        Font font = new Font("Arial", 64);
        Color ellipseColor = GetRandomColor();
        Color textColor = ellipseColor.GetBrightness() < 0.5 ? Color.White : Color.Black;
        SolidBrush ellipseBrush = new SolidBrush(ellipseColor);
        SolidBrush textBrush = new SolidBrush(textColor);
        Bitmap outputImage = new Bitmap(OutputImageSize, OutputImageSize);

        //  Initialize drawing canvas (a.k.a graphics).
        Graphics graphics = Graphics.FromImage(outputImage);

        //  Draw ellipse and text on the canvas.
        graphics.FillEllipse(ellipseBrush, 0, 0, OutputImageSize, OutputImageSize);
        SizeF textSize = graphics.MeasureString(abbreviation, font);
        graphics.DrawString(
            abbreviation,
            font,
            textBrush,
            (OutputImageSize - textSize.Width) / 2,
            (OutputImageSize - textSize.Height) / 2
        );

        //  Write output image as a file and destroy the canvas.
        outputImage.Save(OutputImageFilePath);
        graphics.Dispose();
    }
}
