using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MixologyWeb.Core.Contracts;
using MixologyWeb.Core.Models;
using MixologyWeb.Infrastructure.Repositories;

namespace MixologyWeb.Core.Services
{
    public class UserService : IUserService

    {
        private readonly IApplicationDbRepository repo;

        private readonly char[] separator;

        public UserService(IApplicationDbRepository _repo)
        {
            repo = _repo;
            separator = new char[] { '@' };
        }

        public async Task<UserEditViewModel> GetUserForEdit(string id)
        {
            var user = await repo.GetByIdAsync<IdentityUser>(id);

            return new UserEditViewModel() 
            { 
                Id = user.Id, 
                Name = user.UserName 
            };
        }

        public async Task<IEnumerable<UserListViewModel>> GetUsers()
        {
            return await repo.All<IdentityUser>()
                .Select(u=> new UserListViewModel()
                {
                    Email= u.Email,
                    Name = u.UserName.Split(separator).FirstOrDefault() ?? string.Empty,
                    Id= u.Id,
                })
                .ToListAsync();
        }

        public async Task<bool> UpdateUser(UserEditViewModel model)
        {
            bool result = false;

            var user = await repo.GetByIdAsync<IdentityUser>(model.Id);

            if (user != null)
            {
                user.UserName = model.Name;

                await repo.SaveChangesAsync();
                result = true;
            }

            return result;
        }
    }
}
