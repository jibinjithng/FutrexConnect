import { ICustomer } from './../../models/customer';
export interface ICustomerState {
  customers: ICustomer[];
  selectedCustomer: ICustomer;
  selectedCustomerId: Number;
  loading: Boolean;
  error: any;
}

export const initialCustomerState: ICustomerState = {
  customers: null,
  selectedCustomer: null,
  selectedCustomerId: 0,
  error: null,
  loading: false,
};
