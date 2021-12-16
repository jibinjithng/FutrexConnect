import { CustomerTypes } from './enums/customerTypes.enum';

export interface ICustomerView {
  id: Number;
  customerName: String;
  customerType: CustomerTypes;
  website: String;
  status: String;
}
