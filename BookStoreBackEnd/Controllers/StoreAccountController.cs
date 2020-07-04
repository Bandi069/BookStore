using BookStoreModelLayer;
using BookStoreModelLayer.AccountModel;
using BookStoreModelLayer.IBookManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreBackEnd.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class StoreAccountController : ControllerBase
    {
        private ILogger<StoreAccountController> logger;
        private readonly IAccountManager accountManager;
        public StoreAccountController(IAccountManager account, ILogger<StoreAccountController> log)
        {
            this.accountManager = account;
            // this.logger = log;
            logger = log;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody]BookRegistrationModel bookRegistrationModel)
        {
            try
            {
                var result = await this.accountManager.StoreRegistration(bookRegistrationModel);
                if (result != null)
                {
                    logger.LogInformation("Register details");
                    return this.Ok(result);
                }
                else
                {
                    var jsonobj = new JsonError();
                    jsonobj.ErrorCode = 400;
                    jsonobj.ErrorMessage = "Invalid Credentials";
                    return BadRequest(jsonobj);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPost("StoreLogin")]
       
        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            try
            {
                logger.LogInformation("Login information");
                var result =  this.accountManager.Login(loginModel);
                if (result != null)
                {
                    return Ok(new { token=result });
                }
                else
                {
                    var jsonobj = new JsonError();
                    jsonobj.ErrorCode = 400;
                    jsonobj.ErrorMessage = "Bad request ";
                    return BadRequest(jsonobj);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
