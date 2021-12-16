// using FutrexConnect.Domain.Entities;
// using FutrexConnect.Domain.Interfaces;

// namespace FutrexConnect.Core.Services
// {
//     public class ProductGroupService : IProductGroup
//     {
//         IRepository<ProductGroup> _productgroupRepository;
//         ILogger<ProductGroupService> _logger;

//         public ProductGroupService(ILogger<ProductGroupService> logger,IRepository<ProductGroup> productgroupRepository)
//         {
//             _logger=logger;
//             _productgroupRepository=productgroupRepository;
//         }

//         public Task<IEnumerable<ProductGroup>> GetAllProductGroup()
//         {
//             return _productgroupRepository.GetAllAsync();
//         }

//         public Task<ProductGroup> GetProductGroupByID(long productgroupID)
//         {
//             return _productgroupRepository.GetAsync(productgroupID);
//         }

//         public Task<ProductGroup> CreateProductGroup(ProductGroup productgroup)
//         {
//             productgroup.CreatedOn = DateTime.Now;
//             productgroup.ModifiedOn = DateTime.Now;
//             return _productgroupRepository.AddAsync(productgroup);
//         }

//         public Task<ProductGroup> UpdateProductGroup(ProductGroup productgroup)
//         {
//             productgroup.ModifiedOn = DateTime.Now;
//             return _productgroupRepository.UpdateAsync(productgroup);
//         }
//         public async Task<Boolean> DeleteProductGroup(long productgroupID)
//         {
//             var productgroup = await _productgroupRepository.GetAsync(productgroupID);

//             if (productgroup == null)
//             {
//                 return false;
//             }
//             _productgroupRepository.DeleteAsync(productgroup);
//             return true;
//         }
//     }
// }
