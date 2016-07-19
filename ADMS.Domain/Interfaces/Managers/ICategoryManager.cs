using ADMS.Domain.Entities;
using System;
using System.Collections.Generic;

namespace ADMS.Domain.Interfaces.Managers
{
    public interface ICategoryManager
    {
        void SaveCategory(Category category);

        void UpdateCategory(Category category);

        IEnumerable<Category> GetAll();

        Category GetByID(Guid id);

        IEnumerable<Category> GetAllParentCategories();

        IEnumerable<Category> GetAllSubCategories(Guid categoryId);
    }
}
