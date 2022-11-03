using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Data.Models.Person
{
    public partial class Person
    {
        [NotMapped]
        public EnumPersonType PersonTypeKey 
        { 
            get 
            {
                EnumPersonType type;
                if (Enum.TryParse(this.PersonType, out type))
                {
                    return type;
                }
                return EnumPersonType.GC;
            }
            set 
            {
                this.PersonType = value.ToString();
            } 
        }

        [NotMapped]
        public EnumEmailPromotion EmailPromotionKey 
        { 
            get
            {
                return (EnumEmailPromotion)this.EmailPromotion;
            }
            set
            {
                this.EmailPromotion = (int)value;
            }
        }
    }

    public enum EnumEmailPromotion
    {
        /// <summary>
        /// Contact does not wish to receive e-mail promotions
        /// </summary>
        Non = 0,

        /// <summary>
        /// Contact does wish to receive e-mail promotions from AdventureWorks
        /// </summary>
        Self = 1,

        /// <summary>
        /// Contact does wish to receive e-mail promotions from AdventureWorks and selected partners
        /// </summary>
        All = 2
    }

    public enum EnumPersonType
    {
        /// <summary>
        /// Store Contact
        /// </summary>
        [Display(Name = "Store Contact")]
        SC = 1,

        /// <summary>
        /// Individual(retail) customer
        /// </summary>
        [Display(Name = "Individual(retail) customer")]
        IN = 2,

        /// <summary>
        /// Sales person
        /// </summary>
        [Display(Name = "Sales person")]
        SP = 4,

        /// <summary>
        /// Employee(non - sales)
        /// </summary>
        [Display(Name = "Employee(non - sales)")]
        EM = 8,

        /// <summary>
        /// Vendor contact
        /// </summary>
        [Display(Name = "Vendor contact")]
        VC = 16,

        /// <summary>
        /// General contact
        /// </summary>
        [Display(Name = "General contact")]
        GC = 32
    }
}
