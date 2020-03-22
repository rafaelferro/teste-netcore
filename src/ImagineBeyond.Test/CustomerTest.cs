using ImagineBeyond.Application.Customer.Interfaces;
using ImagineBeyond.Application.Customer.Services;
using ImagineBeyond.Application.Customer.ViewModel;
using ImagineBeyond.Domain;
using ImagineBeyond.Domain.Interfaces.Repositories;
using ImagineBeyond.Repository.Repositorys;
using ImagineBeyond.UI.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ImagineBeyond.Test
{
    public class CustomerTest
    {
        CustomerController controller;
        CustomerViewModel customerView = new CustomerViewModel();
        ICustomerAppService customerAppService;
        private static string mySqlConnectionStringcm = "server=127.0.0.1;userid=root;password=root;database=ImagineBeyond;Convert Zero Datetime = True";


        public CustomerTest()
        {
            var service = new ServiceCollection();


            service.AddTransient<ICustomerAppService, CustomerAppService>();
            service.AddTransient<ICustomerRepository, CustumerRepository>();

            service.AddDbContext<ImagineBeyondContext>(options => options.UseMySql(mySqlConnectionStringcm));


            var provider = service.BuildServiceProvider();
            customerAppService = provider.GetService<ICustomerAppService>();

        }

        [Fact]
        public void TestNewCustomer()
        {
            controller = new CustomerController(customerAppService);
            customerView.Email = "teste2@teste.com";
            customerView.FirstName = "TesteName2";
            customerView.LastName = "TesteLast2";


            var result = controller.NewCustumer(customerView);

            Assert.IsType<OkObjectResult>(result);

        }

        [Fact]
        public void TestgetCustumersById()
        {
            controller = new CustomerController(customerAppService);

            var result = controller.getCustumersById(1);

            Assert.IsType<OkObjectResult>(result);

        }

        [Fact]
        public void TestUpdateCustumer()
        {
            customerView.Email = "teste2@teste.com";
            customerView.FirstName = "TesteName3";
            customerView.LastName = "TesteLast3";
            controller = new CustomerController(customerAppService);

            var result = controller.UpdateCustumer(customerView);

            Assert.IsType<OkObjectResult>(result);

        }

        [Fact]
        public void TestgetCustumers()
        {
            controller = new CustomerController(customerAppService);

            var result = controller.getCustumers();

            Assert.IsType<OkObjectResult>(result);

        }

        [Fact]
        public void TestDeleteCustumer()
        {
            customerView.Email = "teste@teste.com";
            customerView.FirstName = "TesteName2";
            customerView.LastName = "TesteLast2";
            controller = new CustomerController(customerAppService);

            var result = controller.DeleteCustumer(customerView);

            Assert.IsType<OkObjectResult>(result);

        }

    }
}
