using System;

namespace FutrexConnect.Domain.Entities
{
    public class Customer : BaseEntity
    {


        public String CustomerType { get; set; }
        public String CustomerName { get; set; }
        public String Website { get; set; }

        public IList<CustomerAddressDetails> AddressDetails { get; set; }
        public IList<CustomerContactDetails> ContactDetails { get; set; }
        public IList<CustomerSupportingDocuments> SupportingDocuments { get; set; }

    }
}
