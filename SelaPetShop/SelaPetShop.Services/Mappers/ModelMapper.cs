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
                AnimalId = model.Id,
                Name = model.Name,
                Age = model.Age,
                Description = model.Description
            };
        }

        public async Task<AnimalDto> Map(Animal entity)
        {
            return new AnimalDto
            {
                Id = entity.AnimalId,
                Name = entity.Name,
                Age = entity.Age,
                Description = entity.Description,
                Comments = entity.Comments.Where(p => !string.IsNullOrEmpty(p.Comment1)).Select(p => p.Comment1).ToList(),
                //PictureUrls = entity.PictureName.Select(p => p).ToList();
            };
        }
    }
}
