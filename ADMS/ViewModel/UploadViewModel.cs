using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace ADMS.ViewModel
{
    public class UploadViewModel
    {

        public Guid UploadId { get; set; }

        public Guid PostId { get; set; }

        [Required]
        [StringLength(500)]
        public string FileName { get; set; }

        [StringLength(500)]
        public string FilePath { get; set; }

        public List<HttpPostedFileBase> Files { get; set; }
    }
}