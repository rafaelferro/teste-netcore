using ImagineBeyond.Application.Customer.Interfaces;
using ImagineBeyond.Application.Customer.ViewModel;
using ImagineBeyond.Domain;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ImagineBeyond.UI.Web.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private ICustomerAppService customerApp;

        public CustomerController(ICustomerAppService customerAppService)
        {
            customerApp = customerAppService;
        }

        [HttpGet]
        public IActionResult getCustumers()
        {
            try
            {
                var customers = customerApp.Get();
                return Ok(customers);
            }
            catch (Exception e)
            {

                return NotFound("Erro: " + e.Message);

            }

        }

        [HttpGet]
        public IActionResult getCustumersById(int id)
        {
            var customer = customerApp.GetById(id);

            return Ok(customer);
        }

        [HttpPost]
        public IActionResult NewCustumer(CustomerViewModel customer)
        {
            ValidEmail valid = new ValidEmail();
            if (!valid.valid(customer.Email))
                return Ok("Email não é valido");

            try
            {
                customerApp.CreateCostumer(customer);
            }
            catch
            {
                throw new Exception("Erro ao salvar cliente");
            }

            return Ok("Cliente criado com sucesso!");
        }

        [HttpPost]
        public IActionResult UpdateCustumer(CustomerViewModel customer)
        {
            customerApp.UpdateCostumer(customer);

            return Ok("Cliente atualizado com sucesso");
        }

        [HttpPost]
        public IActionResult DeleteCustumer(CustomerViewModel customer)
        {
            customerApp.DeleteCostumer(customer.Id);

            return Ok("Cliente atualizado com sucesso");
        }
    }
}