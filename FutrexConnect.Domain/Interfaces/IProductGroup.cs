using FutrexConnect.Domain.Entities;

namespace FutrexConnect.Domain.Interfaces
{
    public interface IProductGroup
    {
        Task<IEnumerable<ProductGroup>> GetAllProductGroup();

        Task<ProductGroup> GetProductGroupByID(long productgroupID);

        Task<ProductGroup> CreateProductGroup(ProductGroup productgroup);

        Task<ProductGroup> UpdateProductGroup(ProductGroup productgroup);

        Task<Boolean> DeleteProductGroup(long productgroupID);
    } 
}