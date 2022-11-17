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
                //Category = model.Category != null ? model.Category.CategoryName.ToString() : "",
                Age = model.Age,
                Description = model.Description,
                //Comments = model.Comments.Where(c => !string.IsNullOrEmpty(c.Comment1)).Select(c => c.Comment1).ToList(),
                //Photo = model.PictureUrls != null ? model.PictureUrls.ToString() : ""
            };
        }

        public async Task<AnimalDto> Map(Animal entity)
        {
            return new AnimalDto
            {
                Id = entity.AnimalId,
                Name = entity.Name,
                //Category = entity.Category.Select(c => c
                Category = entity.Category != null ? entity.Category.CategoryName.ToString() : "",
                Age = entity.Age,
                Description = entity.Description,
                Comments = entity.Comments.Where(c => !string.IsNullOrEmpty(c.Comment1)).Select(c => c.Comment1).ToList(),
                PictureUrls = entity.Photo != null ? entity.Photo.ToString() : ""
            };
        }
    }
}