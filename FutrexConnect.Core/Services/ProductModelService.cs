// using FutrexConnect.Domain.Entities;
// using FutrexConnect.Domain.Interfaces;

// namespace FutrexConnect.Core.Services
// {
//     public class ProductModelService : IProductModel
//     {
//         IRepository<ProductModel> _productModelRepository;
//         ILogger<ProductModelService> _logger;

//         public ProductModelService(ILogger<ProductModelService> logger,IRepository<ProductModel> productModelRepository)
//         {
//             _logger=logger;
//             _productModelRepository=productModelRepository;
//         }

//         public Task<IEnumerable<ProductModel>> GetAllProductModel()
//         {
//             return _productModelRepository.GetAllAsync();
//         }

//         public Task<ProductModel> GetProductModelByID(long productmodelID)
//         {
//             return _productModelRepository.GetAsync(productmodelID);            
//         }

//         public Task<ProductModel> CreateProductModel(ProductModel productmodel)
//         {
//             productmodel.CreatedOn = DateTime.Now;
//             productmodel.ModifiedOn = DateTime.Now;
//             return _productModelRepository.AddAsync(productmodel);
//         }

//         public Task<ProductModel> UpdateProductModel(ProductModel productmodel)
//         {
//             productmodel.ModifiedOn = DateTime.Now;
//             return _productModelRepository.UpdateAsync(productmodel);
//         }

//         public async Task<Boolean> DeleteProductModel(long productmodelID)
//         {
//             var productmodel = await _productModelRepository.GetAsync(productmodelID);
//             if(productmodel == null)
//             {
//                 return false;                
//             }
//             _productModelRepository.DeleteAsync(productmodel);
//             return true;
//         }

//     }
// }
