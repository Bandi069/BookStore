using BookStoreModelLayer.AccountModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreRepositoryLayer.IRepository
{
    public interface ICustomerDetailsRepo
    {
        Task<string> NewCustomerDetails(CustomerDetailsModel customerDetails);
        List<CustomerDetailsModel> GetCustomerDetails();
        Task<string> UpdateCustomerDetails(CustomerDetailsModel customerDetails);

        Task DeleteCustomerDetails(int id);
    }
}

