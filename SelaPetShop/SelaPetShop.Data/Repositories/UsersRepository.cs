using SelaPetShop.Data.Models;
using SelaPetShop.Data.Contexts;
using System;

namespace SelaPetShop.Data.Repositories
{
    public class UsersRepository : IRepository<User>
    {
        private readonly PetShopDbContext _context;

        public UsersRepository(PetShopDbContext context)
        {
            _context = context;
        }

        public Task<User> Add(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<User> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PageResponse<User>> Get(Filter filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<User> Login(User user)
        {
            var usr = _context.Users.Single(u => u.Username == user.Username && u.Password == user.Password);
            user.Username = usr.Username;
            user.Password = usr.Password;
            return Task.FromResult(usr);
        }

        public async Task<User> Register(User user)
        {
            _context.Users.Add(user);
            var res = await _context.SaveChangesAsync();

            if (res > 0)
                _context.Entry(user).Reload();

            return user;
        }

        public Task<User> Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
