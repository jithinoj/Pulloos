using ADMS.Domain.Entities;

namespace ADMS.Domain.Interfaces.Managers
{
    public interface ICategoryMappingManager
    {
        void SaveCategory(CategoryMapping categoryMap);

        void UpdateCategory(CategoryMapping categoryMap);
    }
}
