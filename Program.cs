using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace RIPHeros
{
    class Program
    {
        static string inputFile = null;
        static string outputFile = null;
        static ImageFormat Format = ImageFormat.Png;
        static string sFormat = "png";
        static void Main(string[] args)
        {
            dealArgs(args);
            Bitmap img = null;
            try
            {
                img = (Bitmap)Image.FromFile(inputFile);
            }
            catch (Exception e)
            {
                Console.WriteLine("Oops,there is an error.");
                Console.Write(e.ToString());
                Environment.Exit(1);
            }
            int w = img.Width;
            int h = img.Height;
            for(int i = 0; i < w; i++)
            {
                for(int j = 0; j < h; j++)
                {
                    double r = img.GetPixel(i, j).R;
                    double g = img.GetPixel(i, j).G;
                    double b = img.GetPixel(i, j).B;
                    double gray = (r*0.299+g*0.587+b*0.114);
                    int Gray = (int)gray;
                    img.SetPixel(i, j, Color.FromArgb(Gray, Gray, Gray));
                }
            }
            try
            {
                img.Save(outputFile, Format);
            }catch(Exception e)
            {
                Console.WriteLine("Oops,there is an error.");
                Console.Write(e.ToString());
                Environment.Exit(1);
            }
        }
        static void dealArgs(string[] args)
        {
            foreach (string arg in args)
            {
                if (arg[0] == 'O')
                {
                    outputFile = "";
                    foreach (char c in arg.Skip(1))
                    {
                        outputFile += c;
                    }
                }
                else if (arg[0] == 'I')
                {
                    inputFile = "";
                    foreach (char c in arg.Skip(1))
                    {
                        inputFile += c;
                    }
                }
                else if (arg[0] == 'F')
                {
                    string f = "";
                    foreach (char c in arg.Skip(1))
                    {
                        f += c;
                    }
                    f = f.ToLowerInvariant();
                    if (f == "jpg" || f == "jpeg")
                    {
                        Format = ImageFormat.Jpeg; sFormat = "jpeg";
                    }
                    else if (f == "png")
                    {
                        Format = ImageFormat.Png; sFormat = "png";
                    }
                    else if (f == "bmp")
                    {
                        Format = ImageFormat.Bmp; sFormat = "bmp";
                    }
                    else if (f == "tiff")
                    {
                        Format = ImageFormat.Tiff; sFormat = "tiff";
                    }
                    else if (f == "ico")
                    {
                        Format = ImageFormat.Icon; sFormat = "ico";
                    }
                }
            }
        }
    }
}
