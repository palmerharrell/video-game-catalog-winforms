using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameCollection_WinForms.Utilities
{
    public class ImageUtilities
    {
        public static readonly string ImageFileFormats = "All files (*.*)|*.*|Bitmap (*.bmp;*.dib)|*.bmp;*.dib|JPEG (*.jpg;*.jpeg;*.jpe;*.jfif)|*.jpg;*.jpeg;*.jpe;*.jfif|GIF (*.gif)|*.gif|PNG (*.png)|*.png|TIFF (*.tif;*.tiff)|*.tif;*.tiff|ICO (*.ico)|*.ico|HEIC (*.heic;*.hif)|*.heic;*.hif|AVIF (*.avif)|*.avif|WEBP (*.webp)|*.webp";
        
        public static byte[] ConvertImageToByteArray(Image image)
        {
            byte[] bytes;
            var stream = new MemoryStream();

            image.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
            bytes = stream.ToArray();

            return bytes;
        }

        public static Image ConvertByteArrayToImage(byte[] bytes)
        {
            var stream = new MemoryStream(bytes);
            Image image = Image.FromStream(stream);

            return image;
        }

    }
}
