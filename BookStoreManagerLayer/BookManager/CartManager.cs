using BookStoreManagerLayer.IBookManager;
using BookStoreModelLayer.AddBook;
using BookStoreRepositoryLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagerLayer.BookManager
{
    public class CartManager :ICartManager
    {
        private readonly ICartRepo cartRepo;
        public CartManager(ICartRepo cart)
        {
            this.cartRepo = cart;
        }

        public async Task<string> AddCart(AddCartModel addCart)
        {
            var addCartResult= await this.cartRepo.AddCart(addCart);
            return addCartResult;
        }

        public int CartCount()
        {
            var count= this.cartRepo.CartCount();
            return count;
        }

        public Task DeleteCart(int id)
        {
            var deleteCart= this.cartRepo.DeleteCart(id);
            return deleteCart;
        }

        public IQueryable GetAllCart(int id)
        {
            var allCart= this.cartRepo.GetCartById(id);
            return allCart;
        }

        public IQueryable GetAllCartValue()
        {
            var cartValue = this.cartRepo.GetAllCartValue();
            return cartValue;
        }

        public Task UpdateCart(AddCartModel addCart)
        {
            var updateCartResult = this.cartRepo.UpdateCart(addCart);
            return updateCartResult;
        }
    }
}
