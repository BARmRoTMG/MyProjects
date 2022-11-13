using SelaPetShop.Models.Dtos;
using SelaPetShop.Models.Entities;
using SelaPetShop.Models.Interfaces;
using System;

namespace SelaPetShop.Services.Mappers
{
    public class AnimalBaseMapper : IMapper<Animal, AnimalDto>
    {
        public Task<Animal> Map(AnimalDto model)
        {
            throw new NotImplementedException();
        }

        public Task<AnimalDto> Map(Animal entity)
        {
            throw new NotImplementedException();
        }
    }
}
