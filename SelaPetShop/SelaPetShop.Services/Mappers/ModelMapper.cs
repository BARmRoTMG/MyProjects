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
                //Comments = model.Comments.Select(c => new UserCommentDto
                //{
                //    CommentId = c.CommentId,
                //    Value = c.Value
                //})
                //Category = model.Category != null ? model.Category.CategoryName.ToString() : "",
                //Comments = model.Comments.Where(c => !string.IsNullOrEmpty(c.Comment1)).Select(c => c.Comment1).ToList(),
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
                //Category = entity.AnimalCategories.Select(c => c.Category).ToString(),
                Comments = entity.Comments.Where(c => !string.IsNullOrEmpty(c.Value)).Select(c => c.Value).ToList(),
                ImageUrls = entity.AnimalImages.Select(i => i.Image.Url).ToList()
            };
        }
    }
}