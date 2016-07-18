using ADMS.Domain.Entities;

namespace ADMS.Domain.Interfaces.Managers
{
    public interface IUserManager
    {

        AspNetUsers GetUserByUsername(string userName);
    }
}
