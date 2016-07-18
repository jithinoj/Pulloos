using ADMS.Domain.Interfaces.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADMS.Domain.Entities;
using ADMS.Domain.Interfaces;
using ADMS.Data;

namespace ADMS.Business
{
    public class CategoryManager : ICategoryManager
    {
        private IUnitOfWork _unitOfWork;

        public CategoryManager()
        {
            _unitOfWork = new UnitOfWork();
        }

        public CategoryManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Category> GetAll()
        {
            return _unitOfWork.CategoryRepository.Get();   
        }

        public IEnumerable<Category> GetAllParentCategories()
        {
            return _unitOfWork.CategoryMappingRepository.Get(x => x.ParentCategory == null || x.ParentCategory == Guid.Empty, includeProperties: "Category")
                                                        .Select(x => x.Category);
                                                 
        }

        public IEnumerable<Category> GetAllSubCategories(Guid categoryId)
        {
            return _unitOfWork.CategoryMappingRepository.Get(x => x.ParentCategory == categoryId, includeProperties: "Category")
                                                        .Select(x => x.Category)
                                                        .ToList();
        }

        public Category GetByID(Guid id)
        {
            return _unitOfWork.CategoryRepository.GetByID(id);
        }

        public void SaveCategory(Category category)
        {
            _unitOfWork.CategoryRepository.Insert(category);
        }

        public void UpdateCategory(Category category)
        {
            _unitOfWork.CategoryRepository.Update(category);
        }
    }
}
