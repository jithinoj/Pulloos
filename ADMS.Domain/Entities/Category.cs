namespace ADMS.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Category")]
    public partial class Category
    {
        public Category()
        {
            CategoryMapping = new HashSet<CategoryMapping>();
            Post = new HashSet<Post>();
        }

        public Guid CategoryId { get; set; }

        [Required]
        [StringLength(500)]
        public string CategoryName { get; set; }

        public virtual ICollection<CategoryMapping> CategoryMapping { get; set; }

        public virtual ICollection<Post> Post { get; set; }
    }
}
