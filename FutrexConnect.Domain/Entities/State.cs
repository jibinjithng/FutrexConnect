using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FutrexConnect.Domain.Entities
{
    public class State : BaseEntity
    {
        public String StateCode { get; set; }
        public String StateName { get; set; }
        public Boolean IsActive { get; set; }

        public long CountryId { get; set; }
        [ForeignKey("CountryId")]
        public Country Country { get; set; }
        public IList<City> Cities { get; set; }
        public IList<CustomerAddressDetails> CustomerAddressDetails { get; set; }
        public IList<Organization> Organizations { get; set; }
        public IList<Individual> Individuals { get; set; }
    }
}
