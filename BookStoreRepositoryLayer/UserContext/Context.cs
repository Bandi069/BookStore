using BookStoreModelLayer.AccountModel;
using BookStoreModelLayer.AddBook;
using BookStoreModelLayer.AddBookModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreRepositoryLayer.UserContext
{

    public class Context :DbContext
    {
        public Context(DbContextOptions<Context> options):base(options)
        {}
        public DbSet<BookRegistrationModel> StoreAccount { get; set; }
        public DbSet<AddBookModel> AddBookDB { get; set; }
        public DbSet<AddCartModel> CartDB { get; set; }
        public DbSet<CustomerDetailsModel> CustomerDetailsDB { get; set; }
    }
}
