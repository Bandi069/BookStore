using BookStoreManagerLayer.IBookManager;
using BookStoreModelLayer;
using BookStoreModelLayer.AddBook;
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
    public class CartController : ControllerBase
    {
        private readonly ICartManager cartManager;
        private readonly ILogger<CartController> logger;
        public CartController(ICartManager cart, ILogger<CartController> log)
        {
            this.cartManager = cart;
            this.logger = log;
        }
        
        [HttpPost]
        public async Task<IActionResult> AddCart([FromBody] AddCartModel addCartModel)
        {
            try
            {
                var result = await this.cartManager.AddCart(addCartModel);
                if (result != null)
                {
                    logger.LogInformation("Book add to cart");
                    return Ok(new { result });
                }
                else
                {
                    var jsonobj = new JsonError();
                    jsonobj.ErrorCode = 405;
                    jsonobj.ErrorMessage = "New book not added cart";
                    return BadRequest(jsonobj);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPut]
        public IActionResult UpdateCart(AddCartModel addCart)
        {
            try
            {
                var result =this.cartManager.UpdateCart(addCart);
                if (result != null)
                {
                    return Ok(new { result });
                }
                else
                {
                    var jsonobj = new JsonError();
                    jsonobj.ErrorCode = 403;
                    jsonobj.ErrorMessage = "Cart book not updated";
                    return BadRequest(jsonobj);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpDelete]
        public  IActionResult DeleteCart(int id)
        {
            try
            {
                var deleteCartResult =  this.cartManager.DeleteCart(id);
                if (deleteCartResult != null)
                {
                    return Ok(new { deleteCartResult });
                }
                else
                {
                    var jsonObj = new JsonError();
                    jsonObj.ErrorCode = 405;
                    jsonObj.ErrorMessage = "New book not added";
                    return BadRequest(jsonObj);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet("getBookCount")]
        public IActionResult CartCount()
        {
            try
            {
                var Count = this.cartManager.CartCount();
                if (Count != 0)
                {
                    return Ok(Count);
                }
                else
                {
                    var jsonObj = new JsonError();
                    jsonObj.ErrorCode = 405;
                    jsonObj.ErrorMessage = "New book not added";
                    return BadRequest(jsonObj);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IQueryable GetAllCartValue()
        {
            return this.cartManager.GetAllCartValue();
        }

        [HttpGet("getAllCart")]
        public IQueryable GetAllCart(int id)
        {
            return this.cartManager.GetAllCart(id);
        }
    }

}

