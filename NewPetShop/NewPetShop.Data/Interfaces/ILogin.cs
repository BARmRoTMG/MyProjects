using System;

namespace NewPetShop.Data.Interfaces
{
    public interface ILogin<T> where T : class
    {
        T GetUser(string username);
    }
}
