using ADMS.Domain.Interfaces.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMS.Files
{
    public class FileHandler : IFileHandler
    {
        public byte[] GetFile(Guid fileId)
        {
            throw new NotImplementedException();
        }

        public void SaveFile(string fileName, byte[] fileContent)
        {
            
        }
    }
}
