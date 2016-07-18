using ADMS.Domain.Entities;
using ADMS.Domain.Interfaces;
using System;

namespace ADMS.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private ADMSContext _context;

        public UnitOfWork()
        {
            _context = new ADMSContext();
        }

        private IRepository<AspNetUsers> userRepository;
        private IRepository<Post> postRepository;
        private IRepository<Category> categoryRepository;
        private IRepository<CategoryMapping> categoryMappingRepository;
        private IRepository<Upload> uploadRepository;



        public IRepository<AspNetUsers> UserRepository
        {
            get
            {
                return userRepository ?? (userRepository = new Repository<AspNetUsers>(_context));
            }
        }

        public IRepository<Post> PostRepository
        {
            get
            {
                return postRepository ?? (postRepository = new Repository<Post>(_context));
            }
        }

        public IRepository<Category> CategoryRepository
        {
            get
            {
                return categoryRepository ?? (categoryRepository = new Repository<Category>(_context));
            }
        }

        public IRepository<CategoryMapping> CategoryMappingRepository
        {
            get
            {
                return categoryMappingRepository ?? (categoryMappingRepository = new Repository<CategoryMapping>(_context));
            }
        }

        public IRepository<Upload> UploadRepository
        {
            get
            {
                return uploadRepository ?? (uploadRepository = new Repository<Upload>(_context));
            }
        }

        public bool Save()
        {
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception dbEx)
            {
                return false;
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
