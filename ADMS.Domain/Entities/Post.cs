namespace ADMS.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web.Script.Serialization;
    [Table("Post")]
    public partial class Post
    {
        public Post()
        {
            Upload = new HashSet<Upload>();
        }

        public Guid PostId { get; set; }

        [Required]
        [StringLength(128)]
        public string PostedBy { get; set; }

        public DateTime PostedAt { get; set; }

        [Required]
        [StringLength(500)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public Guid? CategoryId { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }

        
        public virtual Category Category { get; set; }

        public virtual ICollection<Upload> Upload { get; set; }
    }
}
