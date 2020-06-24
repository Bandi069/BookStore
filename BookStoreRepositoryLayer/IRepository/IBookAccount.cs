using BookStoreModelLayer.AccountModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreRepositoryLayer.IRepository
{
  public interface IBookAccount
    {
        
        Task<int> StoreRegistration(BookRegistrationModel bookRegistrationModel);
        Task<string> StoreLogin(LoginModel loginModel);

    }
}
