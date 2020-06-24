using BookStoreModelLayer.AccountModel;
using BookStoreRepositoryLayer.IRepository;
using BookStoreRepositoryLayer.UserContext;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreRepositoryLayer.Repository
{
    public class BookAccount : IBookAccount
    {
        private readonly Context userContext;
        private readonly IConfiguration configuaration;
        public BookAccount(Context context, IConfiguration configuaration)
        {
            this.userContext = context;

        }
        public Task<int> StoreRegistration(BookRegistrationModel bookRegistrationModel)
        {
            BookRegistrationModel bookcred = new BookRegistrationModel()
            {
                FirstName =bookRegistrationModel.FirstName,
                LastName=bookRegistrationModel.LastName,
                Email=bookRegistrationModel.Email,
                Password=bookRegistrationModel.Password,
                HashCode=bookRegistrationModel.HashCode
            };
            var registeruser = this.userContext.StoreAccount.Add(bookcred);
            var result = this.userContext.SaveChanges();
            return Task.Run(()=>result);
        }
        public Task<string> StoreLogin(LoginModel loginModel)
        {
            return null;
        }


    }
}
