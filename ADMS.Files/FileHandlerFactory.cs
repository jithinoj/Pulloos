using ADMS.Domain.Entities;
using ADMS.Domain.Interfaces.Files;
using ADMS.Domain.Interfaces.Configurations;

namespace ADMS.Files
{
    public class FileHandlerFactory : IFileHandlerFactory
    {
        private IConfigurationSettings _configurationSettings;
        private IThumbnailGenerator _thumbnailGenerator;

        public FileHandlerFactory(IConfigurationSettings configurationSettings, IThumbnailGenerator thumbnailGenerator)
        {
            _configurationSettings = configurationSettings;
            _thumbnailGenerator = thumbnailGenerator;
        }

        public IFileHandler GetFileHandler(Enumerations.FileType fileType)
        {
            switch (fileType)
            {
                case Enumerations.FileType.Image:
                    return new ImageFileHandler(_configurationSettings, _thumbnailGenerator);
                case Enumerations.FileType.Word:
                    return null;
                case Enumerations.FileType.PDF:
                    return null;
                case Enumerations.FileType.Audio:
                    return null;
                case Enumerations.FileType.Video:
                    return null;
                default:
                    return null;
            }
        }
    }
}
