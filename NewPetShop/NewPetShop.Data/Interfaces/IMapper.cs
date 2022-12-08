using System;

namespace NewPetShop.Data.Interfaces
{
    public interface IMapper<Tentity, Tmodel>
    {
        Tentity Map(Tmodel model);
        Tmodel Map(Tentity entity);
    }
}
