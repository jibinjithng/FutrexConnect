// using FutrexConnect.Domain.Entities;
// using FutrexConnect.Domain.Interfaces;

// namespace FutrexConnect.Core.Services
// {
//     public class ProductColorService : IProductColor
//     {
//         IRepository<ProductColor> _productColorRepository;
//         ILogger<ProductColorService> _logger;

//         public ProductColorService(IRepository<ProductColor> productColorRepository,ILogger<ProductColorService> logger)
//         {
//             _productColorRepository=productColorRepository;
//             _logger=logger;
//         }

//         public Task<IEnumerable<ProductColor>> GetAllProductColors(){
//             return _productColorRepository.GetAllAsync();
//         }

//         public Task<ProductColor> GetProductColorByID(long productColorID){
//             return _productColorRepository.GetAsync(productColorID);
//         }

//         public Task<ProductColor> CreateProductColor(ProductColor productColor){
//             productColor.CreatedOn=DateTime.Now;
//             productColor.ModifiedOn=DateTime.Now;
//             return _productColorRepository.AddAsync(productColor);
//         }

//         public Task<ProductColor> UpdateProductColor(ProductColor productColor){
//             productColor.ModifiedOn=DateTime.Now;
//             return _productColorRepository.UpdateAsync(productColor);
//         }

//         public async Task<Boolean> DeleteProdutColor(long productColorID){
//             var productcolor=await _productColorRepository.GetAsync(productColorID);
//             if(productcolor==null){
//                 return false;
//             }
//             _productColorRepository.DeleteAsync(productcolor);
//             return true;
//         }
//     }
// }
