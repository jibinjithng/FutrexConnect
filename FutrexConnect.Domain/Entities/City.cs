using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FutrexConnect.Domain.Entities
{
    public class City : BaseEntity
    {
        public String CityCode { get; set; }
        public String CityName { get; set; }
        public Boolean IsActive { get; set; }
        public long StateId { get; set; }
        [ForeignKey("StateId")]
        public State State { get; set; }
        public IList<CustomerAddressDetails> CustomerAddressDetails { get; set; }
        public IList<Organization> Organizations { get; set; }
        public IList<Individual> Individuals { get; set; }
    }
}
