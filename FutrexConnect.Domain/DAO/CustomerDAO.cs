namespace FutrexConnect.Domain.DAO
{
    public class CustomerDAO
    {
        public long? Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerType { get; set; }
        public string Website { get; set; }

        public IList<CustomerContactDetailsDAO> CustomerContactDetails { get; set; }
        public IList<CustomerAddressDetailsDAO> CustomerAddressDetails { get; set; }
    }

    public class CustomerContactDetailsDAO
    {
        public long? Id { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public string OfficePhone { get; set; }
    }

    public class CustomerAddressDetailsDAO
    {
        public long? Id { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public int Pincode { get; set; }
        public long CityId { get; set; }
        public long StateId { get; set; }
        public long CountryId { get; set; }
    }
}