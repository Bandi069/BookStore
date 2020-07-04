using BookStoreModelLayer.AddBookModel;
using BookStoreRepositoryLayer.IRepository;
using BookStoreRepositoryLayer.UserContext;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreRepositoryLayer.Repository
{
  public class AddBookRepo :IAddBookRepo
    {
        private readonly Context context;
        private readonly IConfiguration configuration;
        public AddBookRepo(Context userContext,IConfiguration config)
        {
            this.context = userContext;
            this.configuration = config;
        }

        public async Task<string> AddBook(AddBookModel addBookModel)
        {
            AddBookModel addbook = new AddBookModel()
            {
                BookId = addBookModel.BookId,
                BookTitle = addBookModel.BookTitle,
                BookDescription = addBookModel.BookDescription,
                BookPrice = addBookModel.BookPrice,
                BookImage = addBookModel.BookImage,
                Author = addBookModel.Author,
               BooksCount = addBookModel.BooksCount,
            };
           var add=  this.context.AddBookDB.AddAsync(addbook);
            var addreturn=  context.SaveChangesAsync();
            await Task.Run(()=>addreturn);
            return "New book added to store";
        }

        public int CountBook()
        {
            var result = this.context.AddBookDB.ToList();
            return result.Count;
        }

        public Task Delete(int bookId)
        {
            var result = this.context.AddBookDB.Where(option => option.BookId == bookId).FirstOrDefault();
            if (result != null)
            {
                this.context.AddBookDB.Remove(result);
            }
            return Task.Run(() => context.SaveChanges()); 
        }

        public List<AddBookModel> Getbook()
        {
            return this.context.AddBookDB.ToList();
        }

        public Task Update(AddBookModel addBookModel)
        {
            var updateresult = this.context.AddBookDB.Where(option => option.BookId == addBookModel.BookId).SingleOrDefault();
            if (updateresult != null)
            {

                updateresult.BookPrice = addBookModel.BookPrice;
                this.context.AddBookDB.Update(updateresult);
                return Task.Run(() => context.SaveChanges());
            }
            return default;
        }

        public async Task<string> UploadImg(int bookId, IFormFile image)
        {
            try
            {
                var stream = image.OpenReadStream();
                var name = image.FileName;
                Account account = new Account(configuration["Cloudinary:CloudName"], configuration["Cloudinary:APIKey"], configuration["Cloudinary:APISecret"]);
                Cloudinary cloudinary = new Cloudinary(account);
                var UploadFile = new ImageUploadParams()
                {
                    File = new FileDescription(name, stream)
                };
                var Imageresult = cloudinary.Upload(UploadFile);

                var file = this.context.AddBookDB.Where(option =>option.BookId == bookId).SingleOrDefault();
                if (file != null)
                {
                    file.BookImage = Imageresult.Url.ToString();
                    this.context.AddBookDB.Update(file);
                    await Task.Run(() => context.SaveChanges());
                    return "Image uploaded successfully";
                }
                return null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
