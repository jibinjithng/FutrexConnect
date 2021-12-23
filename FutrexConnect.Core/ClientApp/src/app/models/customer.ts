export interface ICustomer {
  id: Number;
  customerName: String;
  customerType: String;
  website: String;
  status: Boolean;

  customerContactDetails: ICustomerContactDetails[];
  customerAddressDetails: ICustomerAddressDetails[];
}

export interface ICustomerContactDetails {
  id: Number;
  customerId: Number;
  email: String;
  mobilePhone: String;
  officePhone: String;
}

export interface ICustomerAddressDetails {
  id: Number;
  customerId: Number;
  address1: String;
  address2: String;
  pincode: Number;
  cityId: Number;
  stateId: Number;
  countryId: Number;
}
