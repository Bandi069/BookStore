using BookStoreManagerLayer.IBookManager;
using BookStoreModelLayer.AddBookModel;
using BookStoreRepositoryLayer.IRepository;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagerLayer.BookManager
{
    public class AddBookManager : IAddBookManager
    {
        private readonly IAddBookRepo addBookRepo;
        public AddBookManager(IAddBookRepo addBook)
        {
            this.addBookRepo = addBook;
        }
        public Task<string> Addbook(AddBookModel addBookModel)
        {
            var addbook=this.addBookRepo.AddBook(addBookModel);
            return addbook;
        }

        public int CountBook()
        {
            var bookcount = this.addBookRepo.CountBook();
            return bookcount;
        }

        public Task Delete(int BookId)
        {
            return this.addBookRepo.Delete(BookId);
        }

        public List<AddBookModel> Getbook()
        {
            var resbook = this.addBookRepo.Getbook();
            return resbook;
        }

        public Task Update(AddBookModel addBookModel)
        {
            var upbook = this.addBookRepo.Update(addBookModel);
            return upbook;
        }

        public async Task<string> UploadImg(int bookId, IFormFile Image)
        {
            var imgRes = await this.addBookRepo.UploadImg(bookId, Image);
            return imgRes;
        }
    }
}
