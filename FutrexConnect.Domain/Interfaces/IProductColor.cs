using FutrexConnect.Domain.Entities;

namespace FutrexConnect.Domain.Interfaces
{
    public interface IProductColor
    {
        Task<IEnumerable<ProductColor>> GetAllProductColors();

        Task<ProductColor> GetProductColorByID(long productColorID);

        Task<ProductColor> CreateProductColor(ProductColor productColor);

        Task<ProductColor> UpdateProductColor(ProductColor productColor);

        Task<Boolean> DeleteProdutColor(long productColorID);

    }

}
