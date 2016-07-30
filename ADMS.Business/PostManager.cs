using ADMS.Domain.Entities;
using ADMS.Domain.Interfaces;
using ADMS.Domain.Interfaces.Managers;
using System;
using System.Collections.Generic;

namespace ADMS.Business
{
    public class PostManager : IPostManager
    {
       private IUnitOfWork _unitOfWork;

        public PostManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void SavePost(Post post)
        {
            _unitOfWork.PostRepository.Insert(post);
        }

        public void UpdatePost(Post post)
        {
            _unitOfWork.PostRepository.Update(post);
        }

        public IEnumerable<Post> GetAll()
        {
            return _unitOfWork.PostRepository.Get(includeProperties: "AspNetUsers,Upload");
        }

        public Post GetByID(Guid id)
        {
            return _unitOfWork.PostRepository.GetByID(id);
        }

        public void Delete(Guid postID)
        {
            _unitOfWork.PostRepository.Delete(postID);

        }
    }
}
