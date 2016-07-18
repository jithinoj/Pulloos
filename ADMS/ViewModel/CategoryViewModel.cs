using ADMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ADMS.ViewModel
{
    public class CategoryViewModel
    {
        public Guid CategoryId { get; set; }

        [Required]
        [StringLength(500)]
        public string CategoryName { get; set; }

        public Guid? ParentCategory { get; set; }

        public IEnumerable<Category> Categories { get; set; }
    }
}