import { ICustomer } from './../../models/customer';
export interface ICustomerState {
  customers: ICustomer[];
  selectedCustomer: ICustomer;
}

export const initialCustomerState: ICustomerState = {
  customers: null,
  selectedCustomer: null,
};
