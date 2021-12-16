import { createSelector } from '@ngrx/store';
import { IAppState } from '../app.state';
import { ICustomerState } from './customer.state';

const selectCustomers = (state: IAppState) => state.customers;

export const selectCustomerList = createSelector(
  selectCustomers,
  (state: ICustomerState) => state.customers
);

export const selectSelectedUser = createSelector(
  selectCustomers,
  (state: ICustomerState) => state.selectedCustomer
);
