namespace ADMS.Domain.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Upload")]
    public partial class Upload
    {
        public Guid UploadId { get; set; }

        public Guid PostId { get; set; }

        [Required]
        [StringLength(500)]
        public string FileName { get; set; }

        public string ThumbPath { get; set; }

        [StringLength(500)]
        public string FilePath { get; set; }

        public virtual Post Post { get; set; }
    }
}
