using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ImagineBeyond.Application.Customer.Interfaces;
using ImagineBeyond.Application.Customer.ViewModel;
using ImagineBeyond.Domain.Interfaces.Repositories;
using ImagineBeyond.Customer.Entity;
using System.Linq;

namespace ImagineBeyond.Application.Customer.Services
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerAppService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<CustomerViewModel>> Get()
        {
            var custumers = await _customerRepository.Get();

            List<CustomerViewModel> CVM = new List<CustomerViewModel>();

            foreach (ImagineBeyond.Customer.Entity.CustomerEntity a in custumers)
            {

                CustomerViewModel customer = new CustomerViewModel();
                customer.Id = a.Id;
                customer.FirstName = a.FirstName;
                customer.LastName = a.LastName;
                customer.Email = a.Email;
                CVM.Add(customer);

            }

            IEnumerable<CustomerViewModel> teste = CVM.Select(a=>a);

            return teste;

        }

        public async Task<CustomerViewModel> GetById(int id)
        {
            var customer = await _customerRepository.GetById(id);
            return new CustomerViewModel
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName
            };
        }

        public async Task CreateCostumer(CustomerViewModel costumerViewModel)
        {
            

                var costumer = new ImagineBeyond.Customer.Entity.CustomerEntity(costumerViewModel.FirstName, costumerViewModel.LastName, costumerViewModel.Email);
            await _customerRepository.Create(costumer);
        }

        public async Task UpdateCostumer(CustomerViewModel costumerViewModel)
        {
            var customer = await _customerRepository.GetById(costumerViewModel.Id);
            customer.Update(costumerViewModel.FirstName, costumerViewModel.LastName, costumerViewModel.Email);
            await _customerRepository.Update(customer);
        }

        public async Task DeleteCostumer(int id)
        {
            var customer = await _customerRepository.GetById(id);
            await _customerRepository.Delete(customer);
        }
    }
}