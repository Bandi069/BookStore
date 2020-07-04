using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookStoreModelLayer.AddBook
{
    public class AddCartModel
    {
        private int cartId;
        private int bookId;
        private int bookCount;
        private string orderId;

        [Key]
        public int CartId { get => cartId; set => cartId = value; }
        public int BookId { get => bookId; set => bookId = value; }
        public int BookCount { get => bookCount; set => bookCount = value; }
        public string OrderId { get => orderId; set => orderId = value; }
    }
}
