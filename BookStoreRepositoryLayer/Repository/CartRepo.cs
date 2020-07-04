using BookStoreModelLayer.AddBook;
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
    public class CartRepo : ICartRepo
    {
        private readonly Context userContext;
        private readonly IConfiguration configuaration;
        public CartRepo(Context context, IConfiguration config)
        {
            this.userContext = context;
            this.configuaration = config;
        }

        public async Task<string> AddCart(AddCartModel addCartModel)
        {
            AddCartModel addCart = new AddCartModel()
            {
                CartId = addCartModel.CartId,
                BookId = addCartModel.BookId,
                BookCount = addCartModel.BookCount,
                OrderId = addCartModel.OrderId
            };
            this.userContext.CartDB.Add(addCart);
            var add = this.userContext.SaveChangesAsync();
            await Task.Run(() => add);
            return "Book added to cart";
        }

        public int CartCount()
        {
            var CartBookCount = this.userContext.CartDB.ToList();
            return CartBookCount.Count;
        }

        public Task DeleteCart(int id)
        {
            var DeleteBookCart = this.userContext.CartDB.Where(op => op.CartId == id).FirstOrDefault();
            if (DeleteBookCart != null)
            {
                this.userContext.CartDB.Remove(DeleteBookCart);
                return Task.Run(() => userContext.SaveChanges());

            }
            return null;
        }

        public IQueryable GetCartById(int id)
        {
            var CartBooks = this.userContext.CartDB.Join(this.userContext.AddBookDB,
                           cart => cart.BookId,
                           book => book.BookId,
                           (cart, book) => new
                           {
                               cartId = cart.CartId,
                               Order = cart.OrderId,
                               id = book.BookId,
                               author = book.Author,
                               bookimg = book.BookImage,
                               price = book.BookPrice,
                               noofbook = cart.BookCount
                           });
            return CartBooks;
        }

        public IQueryable GetAllCartValue()
        {
            var CartValues = this.userContext.CartDB.Join(this.userContext.AddBookDB,
               cart => cart.BookId,
               book => book.BookId,
               (cart, book) => new
               {
                   cartId = cart.CartId,
                   Order = cart.OrderId,
                   id = book.BookId,
                   author = book.Author,
                   bookimg = book.BookImage,
                   price = book.BookPrice,
                   noofbook = cart.BookCount
               });
            return CartValues;
        }

        public Task UpdateCart(AddCartModel addCart)
        {
            var UpdateBook = this.userContext.CartDB.Where(op => op.CartId == addCart.CartId).SingleOrDefault();
            if (UpdateBook != null)
            {
                UpdateBook.BookId = addCart.BookId;
                UpdateBook.BookCount = addCart.BookCount;
                this.userContext.CartDB.Update(UpdateBook);
                return Task.Run(() => this.userContext.SaveChanges());
            }
            return default;
        }
    }
}
