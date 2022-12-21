using MixologyWeb.Core.Contracts;
using MixologyWeb.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixologyWeb.Core.Services
{
    public class UserService : IUserService

    {
        public async Task<IEnumerable<UserListViewModel>> GetUsers()
        {
            throw new NotImplementedException();
        }
    }
}
