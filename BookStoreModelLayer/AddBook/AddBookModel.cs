using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookStoreModelLayer.AddBookModel
{
   public class AddBookModel
    {
        private int bookId;
        private string bookTitle;
        private string bookDescription;
        private string author;
        private int bookPrice;
        private string bookImage;
        private int booksCount;

        [Key]
        public int BookId { get => bookId; set => bookId = value; }
        public string BookTitle { get => bookTitle; set => bookTitle = value; }
        public string BookDescription { get => bookDescription; set => bookDescription = value; }
        public string Author { get => author; set => author = value; }
        public int BookPrice { get => bookPrice; set => bookPrice = value; }
        public string BookImage { get => bookImage; set => bookImage = value; }
        public int BooksCount { get => booksCount; set => booksCount = value; }
    }
}
