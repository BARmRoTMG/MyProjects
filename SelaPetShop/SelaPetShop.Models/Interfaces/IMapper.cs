using System;

namespace SelaPetShop.Models.Interfaces
{
    public interface IMapper<Tentity, Tmodel>
    {
        Task<Tentity> Map(Tmodel model);
        Task<Tmodel> Map(Tentity entity);
    }
}
