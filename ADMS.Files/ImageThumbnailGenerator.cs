using ADMS.Domain.Interfaces.Files;
using System;
using System.Drawing;
using System.IO;

namespace ADMS.Files
{
    public class ImageThumbnailGenerator : IThumbnailGenerator
    {       

        public bool GenerateThumbnail(string sourceFilePath, string destinationDirectory, int widthPX, int heightPX)
        {
            try
            {
                Image source = Image.FromFile(sourceFilePath);
                Image thumbnail = source.GetThumbnailImage(widthPX, heightPX, () => false, IntPtr.Zero);

                string thumbFileName = Path.GetFileNameWithoutExtension(sourceFilePath) + "-thumb.jpg";                

                thumbnail.Save(destinationDirectory + thumbFileName);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
