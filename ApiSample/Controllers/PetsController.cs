using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiSample.Controllers
{
    [ApiController]
    [Route("api/pets")]
    public class PetsController : ControllerBase
    {
        public PetsController()
        {

        }

        [HttpGet]
        public List<Pet> Index()
        {
            return new List<Pet>
            {
                new Pet {Name = "Tofy"}
            };
        }

        [HttpGet("{id}")]
        public Pet Get(int id)
        {
            return new Pet { Id= id , Name = "Tofy"};
        }
    }

    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
