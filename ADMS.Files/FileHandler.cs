using ADMS.Domain.Interfaces.Configurations;
using ADMS.Domain.Interfaces.Files;
using System;
using System.Configuration;
using System.IO;

namespace ADMS.Files
{
    public class FileHandler : IFileHandler
    {
        private string _uploadPath;

        public FileHandler(IConfigurationSettings configurationSettings)
        {
            _uploadPath = configurationSettings.UploadFilePath;            
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
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
