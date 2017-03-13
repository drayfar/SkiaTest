namespace SkiaTest
{
    using System;
    using System.Net.Http;

    using SkiaSharp;

    public class Program
    {
        public static void Main(string[] args)
        {
            SKBitmap bitmap;
            using (var client = new HttpClient())
            {
                try
                {
                    var bytes = client.GetByteArrayAsync("https://s-media-cache-ak0.pinimg.com/564x/65/5e/06/655e06b1b452d8001d26fb21ad581e31.jpg");
                    bytes.Wait();
                    bitmap = SKBitmap.Decode(bytes.Result);
                    Console.WriteLine($"Width: {bitmap.Width}; Height: {bitmap.Height}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.ReadLine();
        }
    }
}
