using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace HiddenMessageImage
{
    public class Encode
    {
        public static uint NearestSquare(uint value) => (uint)MathF.Ceiling(MathF.Sqrt(value));
        public static Bitmap CreateNewBitmap(uint charCount)
        {
            uint size = NearestSquare(charCount / 3);
            return new Bitmap((int)size, (int)size);
        }

        public static Image EncodeMessageSequential(string message)
        {
            Bitmap map = CreateNewBitmap((uint) message.Length);
            List<string> split = Split(message, 3).ToList();
            int i = 0;
            for (int y = 0; y < map.Height; y++)
            {
                for (int x = 0; x < map.Width; x++)
                {
                    if (i < split.Count())
                    {
                        EncodePixel(map, x, y, split[i].ToCharArray(), new ColorLocation[]{ ColorLocation.R, ColorLocation.G, ColorLocation.B});
                        i++;
                    }
                }
            }
            return map;
        }

        public static Image EncodeLocations(Tuple<int, int>[] locations, Image image)
        {
            return image;
        }

        private static void EncodePixel(Bitmap bitmap, int x, int y, char[] chars, ColorLocation[] cls)
        {
            if (chars.Length > cls.Length)
            {
                Console.WriteLine("Warning: character array does not match color location array length. Data may be decode incorrectly.");
            }

            int[] colorValues = new int[3] { 0, 0, 0 };
            int i = 0;

            foreach (char c in chars)
            {
                switch(cls[i])
                {
                    case ColorLocation.R:
                        colorValues[0] = (int)c;
                        break;
                    case ColorLocation.G:
                        colorValues[1] = (int)c;
                        break;
                    case ColorLocation.B:
                        colorValues[2] = (int)c;
                        break;
                }

                if (i < cls.Length - 1)
                {
                    i++;
                }
            }
            bitmap.SetPixel(x, y, Color.FromArgb(colorValues[0], colorValues[1], colorValues[2]));
        }

        public static IEnumerable<string> Split(string str, int chunkSize)
        {
            return Enumerable.Range(0, str.Length / chunkSize)
                .Select(i => str.Substring(i * chunkSize, chunkSize));
        }
    }

    public enum ColorLocation
    {
        R,
        G,
        B
    }
}
