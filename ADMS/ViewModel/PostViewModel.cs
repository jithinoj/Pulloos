using ADMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ADMS.ViewModel
{
    public class PostViewModel
    {

        public Guid PostId { get; set; }
    
        
        [StringLength(128)]
        public string PostedBy { get; set; }

        public DateTime? PostedAt { get; set; }

        [Required]
        [StringLength(500)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public Guid? CategoryId { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public string UserName { get; set; }


        public List<Category> Categories { get; set; }

        public List<Upload> Uploads { get; set; }
    }

    public class PostListViewModel
    {
        public IEnumerable<PostViewModel> Posts { get; set; }

        public Guid CurrentUser { get; set; }
    }   
}