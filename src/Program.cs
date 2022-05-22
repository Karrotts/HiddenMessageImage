using HiddenMessageImage;
using System.Drawing;

string text = System.IO.File.ReadAllText("./text.txt");
Encode.EncodeMessageSequential(text).Save("./output.png");
Console.WriteLine(Decode.SequentialDecode((Bitmap)Image.FromFile("./output.png")));