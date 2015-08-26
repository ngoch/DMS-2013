using DMS.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Domain.Services
{
    public class UserService : DomainServiceBase<User>, IUserService
    {
        public UserService(IUserRepository userRepository)
            : base(userRepository)
        {

        }

        public string GeneratePasswordHash(string input)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public bool Authenticate(string userName, string password)
        {
            var passwordHash = GeneratePasswordHash(password);
            return Repository.GetAll().Any(
                user => user.Name == userName && user.PasswordHash == passwordHash
                );
        }

        public User GetByUserName(string userName)
        {
            return Repository.GetAll().SingleOrDefault(user => user.Name == userName);
        }
    }
}
