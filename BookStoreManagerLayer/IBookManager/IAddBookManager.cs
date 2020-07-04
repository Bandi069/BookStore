using BookStoreModelLayer.AddBookModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagerLayer.IBookManager
{
   public interface IAddBookManager
    {
        Task<string> Addbook(AddBookModel addBookModel);
        Task<string> UploadImg(int BookId, IFormFile Image);
        List<AddBookModel> Getbook();
        Task Delete(int BookId);
        int CountBook();
        Task Update(AddBookModel addBookModel);
    }
}
