using BookStoreManagerLayer.IBookManager;
using BookStoreModelLayer;
using BookStoreModelLayer.AccountModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreBackEnd.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class CustomerDetailsController : ControllerBase
    {
        private readonly ICustomerDetailsManager customerDetails;
        private readonly ILogger<CustomerDetailsController> logger;
        public CustomerDetailsController(ICustomerDetailsManager detailsManager,
            ILogger<CustomerDetailsController> log)
        {
            this.logger = log;
            this.customerDetails = detailsManager;
        }
        [HttpPost]
        //[Route]
        public async Task<IActionResult> NewCustomerDetails([FromBody] CustomerDetailsModel customerDetails)
        {
            try
            {
                var result = await this.customerDetails.NewCustomerDetails(customerDetails);
                if (result != null)
                {
                    logger.LogInformation("Add customer");
                    return Ok(new { result });
                }
                else
                {
                    var jsonobj = new JsonError();
                    jsonobj.ErrorCode = 405;
                    jsonobj.ErrorMessage = "New customer not added";
                    return BadRequest(jsonobj);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult Getcustomer()
        {
            try
            {
                List<CustomerDetailsModel> getDetails = this.customerDetails.GetCustomerDetails();
                if (getDetails != null)
                {
                    logger.LogInformation("log infrmation");
                    return Ok(new { getDetails });
                }
                else
                {
                    var jsonObj = new JsonError();
                    jsonObj.ErrorCode = 405;
                    jsonObj.ErrorMessage = "Not get all customers";
                    return BadRequest(jsonObj);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        //[Route]
        public async Task<IActionResult> Update(CustomerDetailsModel detailsModel)
        {

            try
            {
                var updateResult = await this.customerDetails.UpdateCustomerDetails(detailsModel);
                if (updateResult != null)
                {
                    logger.LogInformation("log infrmation");
                    return Ok(new { updateResult });
                }
                else
                {
                    var jsonObj = new JsonError();
                    jsonObj.ErrorCode = 405;
                    jsonObj.ErrorMessage = "Update customers details failed";
                    return BadRequest(jsonObj);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {

                var deleteResult = this.customerDetails.DeleteCustomerDetails(id);
                if (deleteResult != null)
                {
                    logger.LogInformation("log infrmation");
                    return Ok(new { deleteResult });
                }
                else
                {
                    var jsonObj = new JsonError();
                    jsonObj.ErrorCode = 405;
                    jsonObj.ErrorMessage = "Delete customer details failed";
                    return BadRequest(jsonObj);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
