using ADMS.Domain.Interfaces.Configurations;
using ADMS.Domain.Interfaces.Files;
using System;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace ADMS.Files
{
    public class ImageFileHandler : FileHandler, IFileHandler
    {
        private string _uploadPath;
        private IThumbnailGenerator _thumbnailGenerator;

        public ImageFileHandler(IConfigurationSettings configurationSettings, IThumbnailGenerator thumbnailGenerator)
                                :base(configurationSettings.UploadFilePath)
        {
            _uploadPath = configurationSettings.UploadFilePath;
            _thumbnailGenerator = thumbnailGenerator;
        }

        

        public byte[] GetFile(Guid fileName)
        {          
            
            return File.ReadAllBytes(_uploadPath + fileName);
        }

        public bool SaveFile(string fileName, byte[] fileContent)
        {
            try
            {
                File.WriteAllBytes((_uploadPath + fileName), fileContent);

                _thumbnailGenerator.GenerateThumbnail((_uploadPath + fileName), _uploadPath, 100, 100);   
                        
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

    }
}
