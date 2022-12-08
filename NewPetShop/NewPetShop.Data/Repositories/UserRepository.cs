using Microsoft.EntityFrameworkCore;
using NewPetShop.Data.Context;
using NewPetShop.Data.Entities;
using NewPetShop.Data.Exceptions;
using NewPetShop.Data.Interfaces;
using System;

namespace NewPetShop.Data.Repositories
{
    public class UserRepository : ILogin<User>
    {
        private readonly PetShopDbContext _context;

        public UserRepository(PetShopDbContext context)
        {
            _context = context;
        }

        public User GetUser(string username)
        {
            var user = _context.Users.SingleOrDefault(u => u.Username == username);

            if (user == null)
                throw new AnimalNotFoundException($"Username: {username}, was not found.");

            return user;
        }
    }
}
