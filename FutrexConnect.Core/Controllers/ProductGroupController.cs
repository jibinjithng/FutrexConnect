// <<<<<<< HEAD
// ﻿using FutrexConnect.Domain.DAO;
// using FutrexConnect.Domain.Entities;
// using FutrexConnect.Domain.Interfaces;
// using Microsoft.AspNetCore.Mvc;

// namespace FutrexConnect.Core.Controllers;

// [ApiController]
// [Route("[controller]")]
// public class ProductGroupController : ControllerBase
// {
//     private readonly ILogger<CustomerController> _logger;
//     private readonly ICustomer _customerService;

//     public ProductGroupController(ILogger<CustomerController> logger, ICustomer customerService)
//     {
//         _logger = logger;
//         _customerService = customerService;
//     }

//     [HttpGet]
//     public async Task<ActionResult<IEnumerable<CustomerDAO>>> GetCustomers()
//     {
//         return Ok(await _customerService.GetAllCustomers());
//     }

//     [HttpGet("{id}")]
//     public async Task<ActionResult<CustomerDAO>> GetCustomer(long id)
//     {
//         var customer = await _customerService.GetCustomerByID(id);
//         if (customer == null)
//         {
//             return NotFound();
//         }
//         return Ok(customer);
//     }

//     [HttpPost]
//     public async Task<ActionResult<Customer>> CreateCustomer(Customer customer)
//     {
//         var newCustomer = await _customerService.CreateCustomer(customer);

//         return CreatedAtAction(
//             nameof(newCustomer),
//             new { id = newCustomer.Id },
//             customer);
//     }

//     // [HttpPut]
//     // public async Task<ActionResult> UpdateCustomer(CustomerDAO customer)
//     // {
//     //     Customer customerToUpdate = new Customer
//     //     {
//     //         CustomerName = customer.CustomerName,
//     //         CustomerType = customer.CustomerType,
//     //     };
//     //     await _customerService.UpdateCustomer(customerToUpdate);
//     //     return NoContent();
//     // }

//     // [HttpDelete("{id}")]
//     // public async Task<ActionResult> DeleteCustomer(long id)
//     // {
//     //     var deleteResult = await _customerService.DeleteCustomer(id);

//     //     if (!deleteResult)
//     //     {
//     //         return NotFound();
//     //     }

//     //     return NoContent();
//     // }
// }
// =======
// using FutrexConnect.Domain.Entities;
// using FutrexConnect.Domain.Interfaces;
// using Microsoft.AspNetCore.Mvc;

// namespace FutrexConnect.Core.Controllers;

// [ApiController]
// [Route("[controller]")]
// public class ProductGroupController : ControllerBase
// {
//     private readonly ILogger<ProductGroupController> _logger;
//     private readonly IProductGroup _productgroupService;

//     public ProductGroupController(ILogger<ProductGroupController> logger,IProductGroup productgroupService)
//     {
//         _logger = logger;
//         _productgroupService=productgroupService;
//     }

//     [HttpGet]
//     public async Task<ActionResult<IEnumerable<ProductGroup>>> GetProductGroups()
//     {
//         return Ok(await _productgroupService.GetAllProductGroup());
//     }

//     [HttpGet("{id}")]
//     public async Task<ActionResult<ProductGroup>> GetProductGroup(long id)
//     {
//         var productgroup = await _productgroupService.GetProductGroupByID(id);
//         if(productgroup == null){
//             return NotFound();
//         }
//         return Ok(productgroup);
//     }

//     [HttpPost]
//     public async Task<ActionResult<ProductGroup>> CreateProductGroup(ProductGroup productgroup)
//     {
//         var newProductGroup = await _productgroupService.CreateProductGroup(productgroup);
//         return CreatedAtAction(
//             nameof(newProductGroup),
//             new { id = newProductGroup.Id },
//             productgroup);
//     }

//     [HttpPut]
//     public async Task<ActionResult> UpdateProductGroup(ProductGroup productgroup)
//     {
//         await _productgroupService.UpdateProductGroup(productgroup);
//         return NoContent();
//     }

//     [HttpDelete("{id}")]
//     public async Task<ActionResult> DeleteProductGroup(long id)
//     {
//         var deleteResult=await _productgroupService.DeleteProductGroup(id);
//         if(!deleteResult)
//         {
//             return NotFound();
//         }
//         return NoContent();
//     }
// }
// >>>>>>> a764594337c1331f9600c50b93dab202ae4d7f05
