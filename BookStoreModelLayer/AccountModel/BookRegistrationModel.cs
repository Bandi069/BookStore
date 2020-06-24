using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreModelLayer.AccountModel
{
   public class BookRegistrationModel
    {
        private string firstName;
        private string lastName;
        private string email;
        private string password;
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
    }
}
