using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookStoreModelLayer.AccountModel
{
    public class BookRegistrationModel
    {
        private string firstName;
        private string lastName;
        private string email;
        private string password;
        private int id;

        [Key]
       public int Id { get => this.id; set => this.id = value; }
        [Required(ErrorMessage = "Firstname is required")]
        //[RegularExpression(@"^[A-Za-z''-'\$", ErrorMessage="Numerics not allowed")]
        public string FirstName { get => firstName; set => firstName = value; }
        [Required(ErrorMessage = "Lastname is required")]
        //[RegularExpression(@"^[A-Za-z''-'\$", ErrorMessage = "Numerics not allowed")]
        public string LastName { get => lastName; set => lastName = value; }
      
        [EmailAddress]
        public string Email { get => email; set => email = value; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get => password; set => password = value; }

    }
}
