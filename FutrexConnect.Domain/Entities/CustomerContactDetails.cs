using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FutrexConnect.Domain.Entities
{
    public class CustomerContactDetails : BaseEntity
    {
        public String Name { get; set; }
        public String DesignationCategory { get; set; }
        public String Email { get; set; }
        public String OfficePhone { get; set; }
        public String MobilePhone { get; set; }
        public Boolean IsActive { get; set; }
        public long CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

    }
}
