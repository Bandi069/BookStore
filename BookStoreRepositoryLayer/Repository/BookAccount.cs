using BookStoreModelLayer.AccountModel;
using BookStoreRepositoryLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreRepositoryLayer.Repository
{
    public class BookAccount : IBookAccount
    {
        private readonly IBookAccount bookAccount;
        public BookAccount(IBookAccount book)
        {
            this.bookAccount = book;

        }
        public Task<string> StoreRegistration(BookRegistrationModel bookRegistrationModel)
        {
            //BookRegistrationModel book = bookRegistrationModel(){
            //}
            return null;
        }
        public Task<string> StoreLogin(LoginModel loginModel)
        {
            return null;
        }


    }
}
