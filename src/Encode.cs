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
            uint size = NearestSquare(charCount) / 2;
            return new Bitmap((int)size, (int)size);
        }

        public static void EncodeMessageEmpty(string message)
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
                        map.SetPixel(x, y, Color.FromArgb(Convert.ToByte(split[i][0]), Convert.ToByte(split[i][1]), Convert.ToByte(split[i][2])));
                        i++;
                    }
                }
            }
            Image result = (Image)map;
            map.Save("./output.png");
        }

        public static IEnumerable<string> Split(string str, int chunkSize)
        {
            return Enumerable.Range(0, str.Length / chunkSize)
                .Select(i => str.Substring(i * chunkSize, chunkSize));
        }
    }
}
