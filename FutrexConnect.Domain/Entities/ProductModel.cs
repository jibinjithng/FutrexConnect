using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FutrexConnect.Domain.Entities
{
    public class ProductModel : BaseEntity
    {
        public String ProductModelCode { get; set; }
        public String ProductModelName { get; set; }
        public Boolean IsActive { get; set; }

        public IList<Product> Products { get; set; }
    }
}
