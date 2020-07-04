using BookStoreModelLayer.AddBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreRepositoryLayer.IRepository
{
    public interface ICartRepo
    {
            Task<string> AddCart(AddCartModel addCartModel);
            Task UpdateCart(AddCartModel addCart);
            Task DeleteCart(int id);
            int CartCount();
            IQueryable GetCartById(int id);
            IQueryable GetAllCartValue();
    }
}
