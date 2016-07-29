using ADMS.Domain.Entities;
using System;

namespace ADMS.Domain.Interfaces.Managers
{
    public interface IUploadManager
    {
        void SaveUpload(Upload upload);

        Upload GetFileDetails(Guid uploadId);
    }
}
