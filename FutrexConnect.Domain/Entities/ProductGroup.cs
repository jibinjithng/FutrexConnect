using System;

namespace FutrexConnect.Domain.Entities
{
    public class ProductGroup : BaseEntity
    {
        public String ProductGroupCode { get; set; }
        public String ProductGroupName { get; set; }
        public Boolean IsActive { get; set; }

        public IList<Product> Products { get; set; }

    }
}
