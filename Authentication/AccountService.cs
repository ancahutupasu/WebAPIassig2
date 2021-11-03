using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Authentication
{
    public class AccountService : IAccountService
    {
        private readonly List<Account> users;

        public AccountService()
        {
            users = new[]
            {
                new Account
                {
                    UserName = "admin",
                    Password = "admin",
                    Role = "ADMIN"
                },
                new Account
                {
                    UserName = "Timothy",
                    Password = "123456",
                    Role = "MEMBER"
                }
            }.ToList();
        }

        public async Task<Account> ValidateUserAsync(string username, string password)
        {
            var first = users.FirstOrDefault(user => user.UserName.Equals(username));
            if (first == null) throw new Exception("Account not found");
            if (!first.Password.Equals(password)) throw new Exception("Incorrect password");
            return first;
        }
    }
}