using ADMS.Data;
using ADMS.Domain.Entities;
using ADMS.Domain.Interfaces;
using ADMS.Domain.Interfaces.Managers;
using System.Linq;

namespace ADMS.Business
{
    public class UserManager: IUserManager
    {
        IUnitOfWork _unitOfWork;

        public UserManager()
        {
            _unitOfWork = new UnitOfWork();
        }

        public UserManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public AspNetUsers GetUserByUsername(string userName)
        {
            
            return _unitOfWork.UserRepository.Get(x => x.UserName == userName)
                                             .FirstOrDefault();
        }

    }
}
