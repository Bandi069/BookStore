using BookStoreModelLayer.AccountModel;
using BookStoreModelLayer.IBookManager;
using BookStoreRepositoryLayer.Logger;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreBackEnd.Controllers
{
    public class StoreAccountController: ControllerBase
    {
        private ILog logger;
        private readonly IAccountManager accountManager;
        public StoreAccountController(IAccountManager account,ILog log)
        {
            this.accountManager = account;
            this.logger = log;
        }
        [HttpPost]
        [Route("storeaccount")]
        public async Task<IActionResult> Register([FromBody] BookRegistrationModel bookRegistrationModel)
        {
            try
            {
                var result = await this.accountManager.StoreRegistration(bookRegistrationModel);
                return Ok(new { result });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPost]
        [Route("storelogin")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            try
            {
                var result = await this.accountManager.Login(loginModel);
                return Ok(new { result });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
