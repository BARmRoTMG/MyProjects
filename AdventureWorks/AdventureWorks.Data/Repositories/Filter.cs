using AdventureWorks.Data.Models.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Data.Repositories
{
    public class Filter
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public EnumPersonType? PersonType { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }

        public override string ToString()
        {
            return $"page:{PageNumber};size{PageSize};{PersonType};{FirstName};{MiddleName};{LastName}";
        }
    }

    //public class PersonFilter : Filter
    //{
    //    public EnumPersonType? PersonType { get; set; }
    //    public string? FirstNmae { get; set; }
    //    public string? MiddleName { get; set; }
    //    public string? LastName { get; set; }

    //}
}
