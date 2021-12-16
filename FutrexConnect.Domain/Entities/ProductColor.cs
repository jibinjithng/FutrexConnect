using System;

namespace FutrexConnect.Domain.Entities
{
    public class ProductColor : BaseEntity
    {
        public String ProductColorCode { get; set; }
        public String ProductColorName { get; set; }
        public Boolean IsActive { get; set; }

        public IList<Product> Products { get; set; }

    }
}
