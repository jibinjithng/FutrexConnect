using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FutrexConnect.Domain.Entities
{
    public class CustomerAddressDetails : BaseEntity
    {
        public String Address1 { get; set; }
        public String Address2 { get; set; }
        public int PinCode { get; set; }
        public String OfficePhone { get; set; }
        public String OfficeFax { get; set; }
        public String Email { get; set; }
        public String CompanyLogo { get; set; }

        public long CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        public long? CountryId { get; set; }
        [ForeignKey("CountryId")]
        public Country Country { get; set; }
        public long? StateId { get; set; }
        [ForeignKey("StateId")]
        public State State { get; set; }
        public long CityId { get; set; }
        [ForeignKey("CityId")]
        public City City { get; set; }

    }
}
