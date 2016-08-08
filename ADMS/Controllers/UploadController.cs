using ADMS.Domain.Entities;
using ADMS.Domain.Interfaces.Files;
using ADMS.Domain.Interfaces.Managers;
using ADMS.ViewModel;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace ADMS.Controllers
{
    public class UploadController : BaseController
    {
        
        private IUploadManager _uploadManager;
        private IFileHandlerFactory _fileHandlerFactory;

        public UploadController(IFileHandlerFactory fileHandlerFactory, IUploadManager uploadManager)
        {
            _fileHandlerFactory = fileHandlerFactory;
            _uploadManager = uploadManager;
        }

        // GET: Upload
        public ActionResult Add(Guid id)
        {
            var model = new UploadViewModel();

            if (id != null && id != Guid.Empty)
            {
                model.PostId = id;
            }

            return View(model);
        }


        [HttpPost]
        public ActionResult Add(UploadViewModel uploadViewModel)
        {

            if (uploadViewModel.Files.Count > 0)
            {
                foreach (var fileBase in uploadViewModel.Files)
                {
                    var fileId = Guid.NewGuid();
                    var fileName =  GetFileNameFromPostedFile(fileId, fileBase.FileName);

                    bool isSuccessful = StoreFile(fileBase, fileName);

                    if (isSuccessful)
                        _uploadManager.SaveUpload(new Upload
                                                        {
                                                            FileName = fileName.ToString(),
                                                            UploadId = fileId,
                                                            ThumbPath = fileId.ToString() + "-thumb.jpg",
                                                            PostId = uploadViewModel.PostId
                                                        });
                }

                return RedirectToAction("Index", "Posts");
            }

            return View(uploadViewModel);
        }


        #region Private

        private bool StoreFile(HttpPostedFileBase fileBase, string fileName)
        {
            MemoryStream fileStream = new MemoryStream();

            IFileHandler imageHandler = _fileHandlerFactory.GetFileHandler(Enumerations.FileType.Image);

            fileBase.InputStream.CopyTo(fileStream);
            byte[] fileArray = fileStream.ToArray(); 

            return imageHandler.SaveFile(fileName, fileArray);
        }


        private string GetFileNameFromPostedFile(Guid fileId, string fileName)
        {
            int startIndex = fileName.LastIndexOf(".");
            int endIndex = fileName.Length - startIndex;
                            

            string extension = fileName.Substring(startIndex, endIndex);

            return fileId.ToString() + extension;
        }

        #endregion

    }
}