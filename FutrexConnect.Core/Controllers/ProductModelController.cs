// using FutrexConnect.Domain.Entities;
// using FutrexConnect.Domain.Interfaces;
// using Microsoft.AspNetCore.Mvc;

// namespace FutrexConnect.Core.Controllers;

// [ApiController]
// [Route("[controller]")]

// public class ProductModelController : ControllerBase
// {
//     private readonly ILogger<ProductModelController> _logger;
//     private readonly IProductModel _productModelService;

//     public ProductModelController(ILogger<ProductModelController> logger,IProductModel ProductModelService)
//     {
//         _logger=logger;
//         _productModelService=ProductModelService;
//     }

//     [HttpGet]
//     public async Task<ActionResult<IEnumerable<ProductModel>>> GetProductModel()
//     {
//         return Ok(await _productModelService.GetAllProductModel());
//     }

//     [HttpGet("{id}")]
//     public async Task<ActionResult<ProductModel>> GetProductModel(long id)
//     {
//         var productmodel = await _productModelService.GetProductModelByID(id);
//         if(productmodel == null)
//         {
//             return NotFound();
//         }
//         return Ok(productmodel);
//     }

//     [HttpPost]
//     public async Task<ActionResult<ProductModel>> CreateProductModel(ProductModel productmodel)
//     {
//         var newProductmodel= await _productModelService.CreateProductModel(productmodel);
//         return CreatedAtAction(
//             nameof(newProductmodel), 
//             new{id=newProductmodel.Id},
//             productmodel
//             );
//     }

//     [HttpPut]
//     public async Task<ActionResult> UpdateProductModel(ProductModel productmodel)
//     {
//         await _productModelService.UpdateProductModel(productmodel);
//         return NoContent();
//     }

//     [HttpDelete("{id}")]
//     public async Task<ActionResult> DeleteProductModel(long id)
//     {
//         var deleteResult = await _productModelService.DeleteProductModel(id);
//         if(!deleteResult){
//             return NotFound();
//         }
//         return NoContent();
//     }
// }

