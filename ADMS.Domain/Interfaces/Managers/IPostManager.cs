using ADMS.Domain.Entities;
using System;
using System.Collections.Generic;

namespace ADMS.Domain.Interfaces.Managers
{
    public interface IPostManager
    {
        void SavePost(Post post);

        void UpdatePost(Post post);

        IEnumerable<Post> GetAll();

        Post GetByID(Guid id);
    }
        
}
