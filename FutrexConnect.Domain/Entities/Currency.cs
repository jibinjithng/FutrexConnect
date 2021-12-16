using System;

namespace FutrexConnect.Domain.Entities
{
    public class Currency : BaseEntity
    {
        public String CurrencyCode { get; set; }
        public String CurrencyName { get; set; }
        public Boolean IsActive { get; set; }

        public IList<Organization> Organizations { get; set; }
    }
}
