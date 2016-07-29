using System;

namespace ADMS.Domain.Interfaces.Files
{
    public interface IFileHandler
    {        
        bool SaveFile(string fileName, byte[] fileContent);

        byte[] GetFile(Guid fileId);
    }
}
