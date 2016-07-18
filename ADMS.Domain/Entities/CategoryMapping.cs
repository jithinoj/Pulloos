namespace ADMS.Domain.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CategoryMapping")]
    public partial class CategoryMapping
    {
        [Key]
        public Guid CategoryMapId { get; set; }

        public Guid CategoryId { get; set; }

        public Guid? ParentCategory { get; set; }

        public virtual Category Category { get; set; }
    }
}
