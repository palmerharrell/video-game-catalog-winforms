using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameCollection_WinForms.Utilities
{
    public class ImageUtilities
    {
        public static byte[] GetByteArrayFromDiskImage(string path)
        {
            return ConvertImageToByteArray(Image.FromFile(path));
        }

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
