using SixLabors.ImageSharp;
using YourQuoteBoard.Entity;

namespace YourQuoteBoard.Utilities
{
    public class FileFormToPNGConverter
    {

        public async static Task<string> ConvertFileFormToPNG(string fileName, IFormFile coverImage)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await coverImage.CopyToAsync(stream);
            }

            var uniqueFileName = Guid.NewGuid().ToString() + ".png";
            var pngPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", uniqueFileName);

            using (var image = SixLabors.ImageSharp.Image.Load(filePath))
            {
                await image.SaveAsPngAsync(pngPath);
            }

            System.IO.File.Delete(filePath);

            string baseUrl = "https://localhost:7220";
            var webPngPath = $"{baseUrl}/images/{uniqueFileName}";

            return webPngPath;
        }
    }
}
