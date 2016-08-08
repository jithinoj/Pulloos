using ADMS.Domain.Entities;

namespace ADMS.Domain.Interfaces.Files
{
    public interface IFileHandlerFactory
    {
        IFileHandler GetFileHandler(Enumerations.FileType fileType);
    }
}
