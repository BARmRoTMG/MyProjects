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
        Non = 0,
        Self = 1, 
        All = 2
    }

    public enum EnumPersonType
    {
        [Display(Name = "Store Contact")]
        SC = 1,

        [Display(Name = "Individual (retail) Customer")]
        IN = 2,

        [Display(Name = "Sales person")]
        SP = 4,

        [Display(Name = "Employee (non-sales)")]
        EM = 8,

        [Display(Name = "Vendor Contact")]
        VC = 16,

        [Display(Name = "General contact")]
        GC = 32,
    }
}
