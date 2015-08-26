using DMS.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Domain.Services
{
    public interface IUserService : IDomainService<User>
    {
        bool Authenticate(string userName, string password);

        User GetByUserName(string userName);
    }
}
