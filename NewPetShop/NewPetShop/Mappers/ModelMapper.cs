using NewPetShop.Client.Models;
using NewPetShop.Data.Entities;
using NewPetShop.Data.Interfaces;

namespace NewPetShop.Client.Mappers
{
    public class ModelMapper : IMapper<Animal, AnimalDto>
    {
        public Animal Map(AnimalDto model)
        {
            return new Animal
            {
                AnimalId= model.AnimalId,
                Name= model.Name,
                Birthdate= model.Birthdate,
                Description= model.Description,
                Category= model.Category,
                Image= model.Image,
                Comments = model.Comments,
            };
        }

        public AnimalDto Map(Animal entity)
        {
            return new AnimalDto
            {
                AnimalId= entity.AnimalId,
                Name= entity.Name,
                Birthdate= entity.Birthdate,
                Description = entity.Description,
                Category= entity.Category,
                Comments= entity.Comments,
                Image = entity.Image
            };
        }
    }
}