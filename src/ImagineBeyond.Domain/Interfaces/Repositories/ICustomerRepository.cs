using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ImagineBeyond.Customer.Entity;

namespace ImagineBeyond.Domain.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Task Create(Customer.Entity.CustomerEntity customer);

        Task Update(Customer.Entity.CustomerEntity customer);

        Task Delete(Customer.Entity.CustomerEntity customer);

        Task<IEnumerable<Customer.Entity.CustomerEntity>> Get();

        Task<Customer.Entity.CustomerEntity> GetById(int id);
    }
}