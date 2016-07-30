using System.IO;

namespace ADMS.Files
{
    public abstract class FileHandler
    {
        public FileHandler(string basePath)
        {
            if (!Directory.Exists(basePath))
                Directory.CreateDirectory(basePath);
        }
    }
}
