using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FutrexConnect.Domain.Entities
{
    public class Product : BaseEntity
    {
        public String ProductCode { get; set; }
        public String ProductDisplayCode { get; set; }
        public String ProductName { get; set; }
        public Boolean IsActive { get; set; }
        public long? ProductGroupId { get; set; }
        [ForeignKey("ProductGroupId")]
        public ProductGroup ProductGroup { get; set; }
        public long? ProductModelId { get; set; }
        [ForeignKey("ProductModelId")]
        public ProductModel ProductModel { get; set; }
        public long? ProductColorId { get; set; }
        [ForeignKey("ProductColorId")]
        public ProductColor ProductColor { get; set; }

    }
}
