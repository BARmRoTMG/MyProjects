using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewPetShop.Data.Entities
{
    public partial class Animal
    {
        [NotMapped]
        public CategoryEnum CategoryEnumKey
        {
            get
            {
                CategoryEnum type;
                if (Enum.TryParse(this.Category.Name, out type))
                {
                    return type;
                }
                return CategoryEnum.Birds;
            }
            set
            {
                this.Category.Name = value.ToString();
            }
        }
    }
    public enum CategoryEnum
    {
        [Display(Name = "Birds")]
        Birds = 1,

        [Display(Name = "Dogs")]
        Dogs = 2,

        [Display(Name = "Cats")]
        Cats = 4,

        [Display(Name = "Reptiles")]
        Reptiles = 8,
    }
}