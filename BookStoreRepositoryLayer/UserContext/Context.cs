using BookStoreModelLayer.AccountModel;
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
    }
}
