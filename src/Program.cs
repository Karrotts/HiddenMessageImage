using HiddenMessageImage;
using System.Drawing;

string text = System.IO.File.ReadAllText("./text.txt");
Encode.EncodeMessageEmpty(text);
Console.WriteLine(Decode.SequentialDecode((Bitmap)Image.FromFile("./output.png")));