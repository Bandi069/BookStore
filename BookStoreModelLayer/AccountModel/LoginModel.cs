using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
//using System.Web.DynamicData;


namespace BookStoreModelLayer.AccountModel
{
    //[MetadataType(typeof(LoginModel))]
    //public partial class LoginModelc
    //{
    //}
    public class LoginModel
    {
       

        private int id;
        private string email;
        private string password;

        [Key]
        public int Id { get => this.id; set => this.id = value; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
         
        public string Email { get => email; set => email = value; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get => password; set => password = value; }
    }
}
