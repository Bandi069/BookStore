using BookStoreModelLayer.AccountModel;
using BookStoreRepositoryLayer.IRepository;
using BookStoreRepositoryLayer.UserContext;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreRepositoryLayer.Repository
{
    public class BookAccount : IBookAccount
    {
        private readonly Context userContext;
        private readonly IConfiguration configuration;
        public BookAccount(Context context, IConfiguration configuration)
        {
            this.userContext = context;
            this.configuration = configuration;

        }
        public async Task<int> StoreRegistration(BookRegistrationModel bookRegistrationModel)
        {
            BookRegistrationModel bookcred = new BookRegistrationModel()
            {
                Id = bookRegistrationModel.Id,
                FirstName = bookRegistrationModel.FirstName,
                LastName = bookRegistrationModel.LastName,
                Email = bookRegistrationModel.Email,
                Password = bookRegistrationModel.Password,
            };
            var password = PasswordEncryption.EncodePasswordMd5(bookRegistrationModel.Password);
            bookcred.Password = password;
            var registeruser = this.userContext.StoreAccount.Add(bookcred);
            var result = this.userContext.SaveChanges();
            var rest = await Task.Run(() => result);
            return rest;
        }
        public string StoreLogin(LoginModel loginModel)
        {
            if (FindEmail(loginModel.Email, loginModel.Password))
            {
                var token = this.JwtToken(loginModel);
                return token;
            }
            else
            {
                return null;
            }
        }
        public string JwtToken(LoginModel loginModel)
        {
            var claims = new[]
              {
                new Claim(JwtRegisteredClaimNames.Sub,loginModel.Email),
                new Claim(JwtRegisteredClaimNames.Sub,loginModel.Password),
            };
            var key = configuration["Jwt:secretKey"];
            var secretkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var SigningCredentials = new SigningCredentials(secretkey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:url"],
                audience: configuration["Jwt:url"],
                 claims,
                expires: DateTime.Now.AddHours(24),
                signingCredentials: SigningCredentials);

            var securitytoken = new JwtSecurityTokenHandler().WriteToken(token);
            this.userContext.SaveChanges();
            return securitytoken;
        }
        public bool FindEmail(string email, string password)
        {
            var result = this.userContext.StoreAccount.Where(opt => opt.Email == email).SingleOrDefault();
            if (result != null)
            {
                var encrptpassword = PasswordEncryption.EncodePasswordMd5(password);
                var res = this.userContext.StoreAccount.Where(opt => opt.Email == email && opt.Password == encrptpassword).SingleOrDefault();
                if (res != null)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
