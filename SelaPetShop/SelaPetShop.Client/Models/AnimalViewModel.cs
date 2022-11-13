using SelaPetShop.Models.Dtos;
using System.ComponentModel.DataAnnotations;

namespace SelaPetShop.Client.Models
{
    public class AnimalViewModel : AnimalDto
    {
        public AnimalViewModel()
        {
            Comments = new List<string>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Animal Name")]
        public string Name { get; set; }

        public ICollection<string> Comments { get; set; }
    }
}
