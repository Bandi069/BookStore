using BookStoreModelLayer.AccountModel;
using BookStoreRepositoryLayer.IRepository;
using BookStoreRepositoryLayer.UserContext;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreRepositoryLayer.Repository
{
    public class CustomerDetailsRepo : ICustomerDetailsRepo
    {
        private readonly Context userContext;
        private readonly IConfiguration configuration;
        public CustomerDetailsRepo(Context context, IConfiguration config)
        {
            this.configuration = config;
            this.userContext = context;
        }
        public async Task<string> NewCustomerDetails(CustomerDetailsModel customerDetails)
        {
            CustomerDetailsModel newCustomer = new CustomerDetailsModel()
            {
                Name = customerDetails.Name,
                Phonenumber = customerDetails.Phonenumber,
                Pincode = customerDetails.Pincode,
                Locality = customerDetails.Locality,
                Address = customerDetails.Address,
                City = customerDetails.City,
                Landmark = customerDetails.Landmark,
                Type = customerDetails.Type
            };
            this.userContext.CustomerDetailsDB.Add(newCustomer);
            await Task.Run(() => userContext.SaveChanges());
            return "New customer added";
        }

        public Task DeleteCustomerDetails(int id)
        {
            var deleteResult = this.userContext.CustomerDetailsDB.Where(op => op.Id == id).FirstOrDefault();
            if (deleteResult != null)
            {
                this.userContext.CustomerDetailsDB.Remove(deleteResult);
            }
            return Task.Run(() => userContext.SaveChanges());
        }

        public List<CustomerDetailsModel> GetCustomerDetails()
        {
            return this.userContext.CustomerDetailsDB.ToList();
        }

        public async Task<string> UpdateCustomerDetails(CustomerDetailsModel existedCustomerDetails)
        {
            var updateCustomerResult = this.userContext.CustomerDetailsDB.
                Where(op => op.Id == existedCustomerDetails.Id).FirstOrDefault();
            if (updateCustomerResult != null)
            {
                updateCustomerResult.Name = existedCustomerDetails.Name;
                updateCustomerResult.Phonenumber = existedCustomerDetails.Phonenumber;
                updateCustomerResult.Pincode = existedCustomerDetails.Pincode;
                updateCustomerResult.Locality = existedCustomerDetails.Locality;
                updateCustomerResult.Address = existedCustomerDetails.Address;
                updateCustomerResult.City = existedCustomerDetails.City;
                updateCustomerResult.Landmark = existedCustomerDetails.Landmark;
                updateCustomerResult.Type = existedCustomerDetails.Type;
                this.userContext.CustomerDetailsDB.Update(updateCustomerResult);
                await Task.Run(() => userContext.SaveChanges());
                return "Customer updation succesfull";
            }
            else
            {
                return null;
            }
        }
    }
}
