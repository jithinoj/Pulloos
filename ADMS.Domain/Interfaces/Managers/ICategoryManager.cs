using ADMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
