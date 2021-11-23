using Microsoft.AspNetCore.Mvc;
using Server.Commands;
using Server.Models;
using System;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICommandService _commands;

        public CustomerController(ICommandService commands)
        {
            _commands = commands ?? throw new ArgumentNullException(nameof(commands));
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(string id)
        {
            var customer = _commands.GetCustomer(id);

            if (customer == null) return BadRequest();

            return Ok(customer);
        }

        [HttpGet]
        [Route("all")]
        public IActionResult GetAll()
        {
            var customers = _commands.GetCustomers();

            return Ok(customers);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Customers customer)
        {
            customer.CustomerId = Guid.NewGuid().ToString().Substring(0, 5);
            _commands.AddCustomer(customer);

            return Ok(customer);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(string id)
        {
            _commands.RemoveCustomer(id);

            return Ok();
        }
    }
}
