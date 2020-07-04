using BookStoreManagerLayer.IBookManager;
using BookStoreModelLayer;
using BookStoreModelLayer.AddBookModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    public class AddBookController :ControllerBase
    {
        private readonly ILogger<AddBookController> logger;
        private readonly IAddBookManager addBookManager;
        public AddBookController(IAddBookManager addBook, ILogger<AddBookController> log)
        {
            this.addBookManager = addBook;
            this.logger = log;
        }
        
        [HttpPost]
        public async Task<IActionResult> Addbook([FromBody] AddBookModel addBookModel)
        {
            try
            {
                var result = await this.addBookManager.Addbook(addBookModel);
                if (result != null) {
                    logger.LogInformation("Add book information");
                    return Ok(new { result });
                }
                else
                {
                    var jsonobj = new JsonError();
                    jsonobj.ErrorCode = 405;
                    jsonobj.ErrorMessage = "New book not added";
                    return BadRequest(jsonobj);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("UploadImage")]
        public async Task<IActionResult> Uploadimg(int bookId, IFormFile image)
        {
            try
            {
                var imgResult = await this.addBookManager.UploadImg(bookId, image);
                if (imgResult != null)
                {
                    return Ok(new { imgResult });
                }
                else
                {
                    var jsonObj = new JsonError();
                    jsonObj.ErrorCode = 405;
                    jsonObj.ErrorMessage = "Image not uploaded";
                    return BadRequest(jsonObj);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult getBook()
        {
            try
            {
                List<AddBookModel> BookList = this.addBookManager.Getbook();
                if (BookList != null)
                {
                    return Ok(new { BookList });
                }
                else
                {
                    var jsonobj = new JsonError();
                    jsonobj.ErrorCode = 405;
                    jsonobj.ErrorMessage = "Error in get books list";
                    return BadRequest(jsonobj);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public  IActionResult updateBook(AddBookModel addBookModel)
        {

            try
            {
                var Update = this.addBookManager.Update(addBookModel);
                if (Update != null)
                {
                    return Ok(new { Update });
                }
                else
                {
                    var jsonobj = new JsonError();
                    jsonobj.ErrorCode = 405;
                    jsonobj.ErrorMessage = "Update failed";
                    return BadRequest(jsonobj);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult deleteBook(int bookId)
        {
            try
            {
                var delete = this.addBookManager.Delete(bookId);
                if (delete != null)
                {
                    return Ok(new { delete });
                }
                else
                {
                    var jsonobj = new JsonError();
                    jsonobj.ErrorCode = 403;
                    jsonobj.ErrorMessage = "Book deletion unsucessful";
                    return BadRequest(jsonobj);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
