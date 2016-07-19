using System;
using ADMS.Domain.Entities;
using ADMS.Domain.Interfaces.Managers;
using ADMS.Domain.Interfaces;

namespace ADMS.Business
{
    public class CategoryMappingManager : ICategoryMappingManager
    {
        private IUnitOfWork _unitOfWork;
        
        public CategoryMappingManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public void SaveCategory(CategoryMapping categoryMap)
        {
            _unitOfWork.CategoryMappingRepository.Insert(categoryMap);
        }

        public void UpdateCategory(CategoryMapping categoryMap)
        {
            _unitOfWork.CategoryMappingRepository.Update(categoryMap);
        }
    }
}
