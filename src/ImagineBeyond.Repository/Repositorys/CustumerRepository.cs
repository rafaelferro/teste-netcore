using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImagineBeyond.Customer.Entity;
using ImagineBeyond.Domain;
using ImagineBeyond.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ImagineBeyond.Repository.Repositorys
{

    public class CustumerRepository : ICustomerRepository
    {
        private ImagineBeyondContext context;

        public CustumerRepository(ImagineBeyondContext cont)
        {
            context = cont;
        }

        public async Task Create(Customer.Entity.CustomerEntity customer)
        {
            context.Add(customer);
            await context.SaveChangesAsync();
        }

        public async Task Delete(Customer.Entity.CustomerEntity customer)
        {
            context.Remove(customer);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Customer.Entity.CustomerEntity>> Get()
        {
            IEnumerable<CustomerEntity> customer = context.Customer.Select(a => a);
            return customer;
        }

        public async Task<Customer.Entity.CustomerEntity> GetById(int id)
        {
            var customer = await context.Customer.FirstOrDefaultAsync(a => a.Id == id);
            return customer;
        }

        public async Task Update(Customer.Entity.CustomerEntity customer)
        {
            context.Update(customer);
            await context.SaveChangesAsync();
        }
    }
}
