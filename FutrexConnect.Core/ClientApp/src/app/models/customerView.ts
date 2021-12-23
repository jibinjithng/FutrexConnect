import { CustomerTypes } from './enums/customerTypes.enum';

export interface ICustomerView {
  id: Number;
  customerName: String;
  customerType: CustomerTypes;
  website: String;
  status: String;

  contactDetailsId: Number;
  email: String;
  mobilePhone: String;
  officePhone: String;

  customerAddressDetailsId: Number;
  address1: String;
  address2: String;
  pincode: Number;
  cityId: Number;
  stateId: Number;
  countryId: Number;
}
