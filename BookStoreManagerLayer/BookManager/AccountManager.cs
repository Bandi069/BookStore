using BookStoreModelLayer.AccountModel;
using BookStoreModelLayer.IBookManager;
using BookStoreRepositoryLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreModelLayer.BookManager
{
    public class AccountManager : IAccountManager
    {
        private readonly IBookAccount bookAccount;
        public AccountManager(IBookAccount book)
        {
            this.bookAccount = book;
        }
        public string Login(LoginModel loginModel)
        {
            var res = this.bookAccount.StoreLogin(loginModel);
            if (res != null)
            {
                return res;
            }
            else
            {
                return null;
            }
        }

        public async Task<string> StoreRegistration(BookRegistrationModel bookRegistrationModel)
        {
            await this.bookAccount.StoreRegistration(bookRegistrationModel);
            return "Registration successful";
        }
    }
}
