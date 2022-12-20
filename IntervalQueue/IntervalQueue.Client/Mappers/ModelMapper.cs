using IntervalQueue.Client.Models;
using IntervalQueue.Data.Entities;
using IntervalQueue.Data.Interfaces;

namespace IntervalQueue.Client.Mappers
{
    public class ModelMapper : IMapper<Customer, CustomerDto>
    {
        public Customer Map(CustomerDto model)
        {
            return new Customer
            {
                Id = model.Id,
                Name = model.Name,
                EntryTime = model.EntryTime,
                SerialNumber = model.SerialNumber,
            };
        }

        public CustomerDto Map(Customer entity)
        {
            return new CustomerDto
            {
                Id = entity.Id,
                Name = entity.Name,
                EntryTime = entity.EntryTime,
                SerialNumber = entity.SerialNumber,
            };
        }
    }
}
