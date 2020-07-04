using BookStoreModelLayer.AccountModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreModelLayer.IBookManager
{
   public interface IAccountManager
    {
        Task<string> StoreRegistration(BookRegistrationModel bookRegistrationModel);

        string Login(LoginModel loginModel);
    }
}
