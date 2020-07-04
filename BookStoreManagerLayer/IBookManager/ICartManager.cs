using BookStoreModelLayer.AddBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagerLayer.IBookManager
{
    public interface ICartManager
    {
        Task<string> AddCart(AddCartModel addCart);
        Task UpdateCart(AddCartModel addCart);
        Task DeleteCart(int id);
        int CartCount();
        IQueryable GetAllCartValue();
        IQueryable GetAllCart(int id);
    }
}
