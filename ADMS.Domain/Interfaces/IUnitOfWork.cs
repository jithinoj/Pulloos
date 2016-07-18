using ADMS.Domain.Entities;
using System;

namespace ADMS.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<AspNetUsers> UserRepository { get; }
        IRepository<Post> PostRepository { get; }
        IRepository<Category> CategoryRepository { get; }
        IRepository<CategoryMapping> CategoryMappingRepository { get; }
        IRepository<Upload> UploadRepository { get; }

        bool Save();
    }
}
