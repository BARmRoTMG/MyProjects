using SelaPetShop.Models.Dtos;
using SelaPetShop.Models.Entities;
using SelaPetShop.Models.Interfaces;
using System;

namespace SelaPetShop.Services.Mappers
{
    public class ModelMapper : IMapper<Animal, AnimalDto>
    {
        public async Task<Animal> Map(AnimalDto model)
        {
            return new Animal
            {
                AnimalId = model.AnimalId,
                Name = model.Name,
                Birthdate = model.Birthdate,
                Description = model.Description,
                Comments = model.Comments,
                Category = model.Category,
                Image = model.Image,
            };
        }

        public async Task<AnimalDto> Map(Animal entity)
        {
            return new AnimalDto
            {
                AnimalId = entity.AnimalId,
                Name = entity.Name,
                Birthdate = entity.Birthdate,
                Description = entity.Description,
                Category = entity.Category,
                Comments = entity.Comments,
                Image = entity.Image,
            };
        }
    }
}