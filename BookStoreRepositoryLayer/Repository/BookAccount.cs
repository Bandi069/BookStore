using BookStoreModelLayer.AccountModel;
using BookStoreRepositoryLayer.IRepository;
using BookStoreRepositoryLayer.UserContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreRepositoryLayer.Repository
{
    public class BookAccount : IBookAccount
    {
        private readonly Context userContext;
        private readonly IConfiguaration configuaration;
        public BookAccount(Context context, IConfiguaration configuaration)
        {
            this.userContext = context;

        }
        public Task<string> StoreRegistration(BookRegistrationModel bookRegistrationModel)
        {
            BookRegistrationModel bookcred = BookRegistrationModel(){
            }
            return null;
        }
        public Task<string> StoreLogin(LoginModel loginModel)
        {
            return null;
        }


    }
}
