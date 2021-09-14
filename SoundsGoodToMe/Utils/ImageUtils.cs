using System;
using System.Drawing;
using System.Threading.Tasks;
using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.Processing;
using Color = SixLabors.ImageSharp.Color;
using PointF = SixLabors.ImageSharp.PointF;

namespace SoundsGoodToMe.Utils
{
    public static class ImageUtils
    {
        public static async Task AsyncConvertImage(string filePath, string outputPath, string font, string hexColor)
        {
            var sysDrawColor = ColorTranslator.FromHtml(hexColor);
            var color = Color.FromRgba(sysDrawColor.R, sysDrawColor.G, sysDrawColor.B, sysDrawColor.A);
            
            using var img = await Image.LoadAsync(filePath);
            using var imageAcronym = DrawText(img, Program.CurrentAcronym.Abbreviated, font, 70f, color, true);
            using var imageFull = DrawText(imageAcronym, Program.CurrentAcronym.Expanded, font, 30f, color, false);

            await imageFull.SaveAsync(outputPath);
        }

        private static Image DrawText(Image oldImage, string text, string fontName, float fontSize, Color color, bool isAbbreviated)
        {
            var imageSize = oldImage.Size();
            var font = SystemFonts.CreateFont(fontName, fontSize);
            var textSize = TextMeasurer.Measure(text, new RendererOptions(font));
            
            // scale factor to fill the screen, then half that
            var scalingFactor = Math.Min(imageSize.Width / textSize.Width, imageSize.Height / textSize.Height);
            var scaledFont = new Font(font, scalingFactor * font.Size * 0.5f);
            var scaledTextSize = TextMeasurer.Measure(text, new RendererOptions(scaledFont));

            // position text higher if its abbreviated, lower if its expanded
            var heightPos = imageSize.Height / 2f - scaledTextSize.Height / 2f;
            var pos = new PointF(imageSize.Width / 2f - scaledTextSize.Width / 2f,
                isAbbreviated ? heightPos - scaledTextSize.Height / 2f : heightPos + scaledTextSize.Height / 2f);
            
            return oldImage.Clone(ctx => ctx.DrawText(text, scaledFont, color, pos));
        }
    }
}