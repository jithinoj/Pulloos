using System;
using ADMS.Domain.Entities;
using ADMS.Domain.Interfaces.Managers;
using ADMS.Domain.Interfaces;

namespace ADMS.Business
{
    public class UploadManager : IUploadManager
    {
        private IUnitOfWork _unitOfWork;

        public UploadManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Upload GetFileDetails(Guid uploadId)
        {
            return _unitOfWork.UploadRepository.GetByID(uploadId);
        }

        public void SaveUpload(Upload upload)
        {
            _unitOfWork.UploadRepository.Insert(upload);
        }
    }
}
