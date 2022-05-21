using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace HiddenMessageImage
{
    public class Decode
    {
        public static string SequentialDecode(Bitmap image)
        {
            string output = "";
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    output += DecodePixel(image.GetPixel(x, y));
                }
            }
            return output;
        }
        public static string DecodePixel(Color color)
        {
            string data = "";
            data += (char)color.R;
            data += (char)color.G;
            data += (char)color.B;
            return data;
        }
    }
}
