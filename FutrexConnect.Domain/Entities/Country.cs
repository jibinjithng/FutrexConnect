using System;

namespace FutrexConnect.Domain.Entities
{
    public class Country : BaseEntity
    {
        public String CountryCode { get; set; }
        public String CountryName { get; set; }
        public String CountryPhoneCode { get; set; }
        public Boolean IsActive { get; set; }

        public IList<State> States { get; set; }
        public IList<CustomerAddressDetails> CustomerAddressDetails { get; set; }
        public IList<Organization> Organizations { get; set; }
        public IList<Individual> Individuals { get; set; }
    }
}
