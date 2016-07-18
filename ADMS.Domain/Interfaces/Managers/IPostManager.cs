using ADMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
