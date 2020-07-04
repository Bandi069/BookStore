using BookStoreModelLayer.AccountModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagerLayer.IBookManager
{
    public interface ICustomerDetailsManager
    {
        Task<string> NewCustomerDetails(CustomerDetailsModel newCustomer);
        List<CustomerDetailsModel> GetCustomerDetails();

        Task<string> UpdateCustomerDetails(CustomerDetailsModel customerDetailsModel);

        Task DeleteCustomerDetails(int id);
    }
}
