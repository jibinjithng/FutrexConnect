using FutrexConnect.Domain.Entities;

namespace FutrexConnect.Domain.Interfaces
{
    public interface IProductModel
    {
        Task<IEnumerable<ProductModel>> GetAllProductModel();

        Task<ProductModel> GetProductModelByID (long productmodelID);

        Task<ProductModel> CreateProductModel(ProductModel productmodel);

        Task<ProductModel> UpdateProductModel(ProductModel productmodel);

        Task<Boolean> DeleteProductModel(long productmodelID);
    }
}
