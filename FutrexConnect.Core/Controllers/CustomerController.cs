using FutrexConnect.Domain.DAO;
using FutrexConnect.Domain.Entities;
using FutrexConnect.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FutrexConnect.Core.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ILogger<CustomerController> _logger;
    private readonly ICustomer _customerService;

    public CustomerController(ILogger<CustomerController> logger, ICustomer customerService)
    {
        _logger = logger;
        _customerService = customerService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerDAO>>> GetCustomers()
    {
        return Ok(await _customerService.GetAllCustomers());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerDAO>> GetCustomer(long id)
    {
        var customer = await _customerService.GetCustomerByID(id);
        if (customer == null)
        {
            return NotFound();
        }
        return Ok(customer);
    }

    [HttpPost]
    public async Task<ActionResult<Customer>> CreateCustomer(Customer customer)
    {
        var newCustomer = await _customerService.CreateCustomer(customer);

        return CreatedAtAction(
            nameof(newCustomer),
            new { id = newCustomer.Id },
            customer);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateCustomer(CustomerDAO customer)
    {
        Customer customerToUpdate = new Customer
        {
            CustomerName = customer.CustomerName,
            CustomerType = customer.CustomerType,
        };
        await _customerService.UpdateCustomer(customerToUpdate);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCustomer(long id)
    {
        var deleteResult = await _customerService.DeleteCustomer(id);

        if (!deleteResult)
        {
            return NotFound();
        }

        return NoContent();
    }
}
