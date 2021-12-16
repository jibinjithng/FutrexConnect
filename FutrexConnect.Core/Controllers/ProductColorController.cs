// using FutrexConnect.Domain.Entities;
// using FutrexConnect.Domain.Interfaces;
// using Microsoft.AspNetCore.Mvc;

// namespace FutrexConnect.Core.Controllers;

// [ApiController]
// [Route("[controller]")]
// public class ProductColorController : ControllerBase
// {
//     private readonly ILogger<ProductColorController> _logger;
//     private readonly IProductColor _productColorService;

//     public ProductColorController(ILogger<ProductColorController> logger,IProductColor productColorService){
//         _logger=logger;
//         _productColorService=productColorService;
//     }

//     [HttpGet]
//     public async Task<ActionResult<IEnumerable<ProductColor>>> GetProductColors(){
//         return Ok(await _productColorService.GetAllProductColors());
//     }

//     [HttpGet("{id}")]
//     public async Task<ActionResult<ProductColor>> GetProductColor(long id)
//     {
//         var productcolor = await _productColorService.GetProductColorByID(id);
//         if(productcolor == null){
//             return NotFound();
//         }
//         return Ok(productcolor);
//     }

//     [HttpPost]
//     public async Task<ActionResult<ProductColor>> CreateProductColor(ProductColor productColor){
//         var newProductColor=await _productColorService.CreateProductColor(productColor);
//         return CreatedAtAction(
//             nameof(ProductColor),
//             new {id=newProductColor.Id},
//             productColor);
//     }

//     [HttpPut]
//     public async Task<ActionResult<ProductColor>> UpdateProductColor(ProductColor productColor){
//         await _productColorService.UpdateProductColor(productColor);
//         return NoContent();
//     }

//     [HttpDelete]
//     public async Task<ActionResult<ProductColor>> DeleteProdutColor(long id)
//     {
//         var deleteResult=await _productColorService.DeleteProdutColor(id);

//         if(!deleteResult){
//             return NotFound();
//         }

//         return NoContent();
//     }
// }
