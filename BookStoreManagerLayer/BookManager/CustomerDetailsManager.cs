using BookStoreManagerLayer.IBookManager;
using BookStoreModelLayer.AccountModel;
using BookStoreRepositoryLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagerLayer.BookManager
{
    public class CustomerDetailsManager : ICustomerDetailsManager
    {
        private readonly ICustomerDetailsRepo customerDetails;
        public CustomerDetailsManager(ICustomerDetailsRepo detailsRepo)
        {
            this.customerDetails = detailsRepo;
        }

        public Task DeleteCustomerDetails(int id)
        {
            var deleteResult = this.customerDetails.DeleteCustomerDetails(id);
            return deleteResult;
        }

        public List<CustomerDetailsModel> GetCustomerDetails()
        {
            var getResult = this.customerDetails.GetCustomerDetails();
            return getResult;
        }

        public Task<string> NewCustomerDetails(CustomerDetailsModel newCustomer)
        {
            var newResult = this.customerDetails.NewCustomerDetails(newCustomer);
            return newResult;
        }

        public Task<string> UpdateCustomerDetails(CustomerDetailsModel customerDetailsModel)
        {
            var updateResult = this.customerDetails.UpdateCustomerDetails(customerDetailsModel);
            return updateResult;
        }
    }
}
