using ADMS.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADMS.Controllers
{
    public class UploadController : BaseController
    {
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
                    MemoryStream fileStream = new MemoryStream();
                    fileBase.InputStream.CopyTo(fileStream);
                    byte[] fileArray = fileStream.ToArray();

                }

            }

            return View(uploadViewModel);
        }
    }
}