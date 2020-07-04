using BookStoreModelLayer.AddBookModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreRepositoryLayer.IRepository
{
    public interface IAddBookRepo
    {
        Task<string> AddBook(AddBookModel addBookModel);
        Task<string> UploadImg(int bookId, IFormFile image);
        Task Update(AddBookModel addBookModel);
        Task Delete(int id);
        int CountBook();
        List<AddBookModel> Getbook();
        
    }
}
