import { createSelector } from '@ngrx/store';
import { IAppState } from '../app.state';
import { ICustomerState } from './customer.state';

const customerState = (state: IAppState) => state.customerState;

export const selectCustomerList = createSelector(
  customerState,
  (state: ICustomerState) => state.customers
);

export const selectCustomer = createSelector(
  customerState,
  (state: ICustomerState) => {
    return state.selectedCustomer;
  }
);

export const selectError = createSelector(
  customerState,
  (state: ICustomerState) => {
    return state.error;
  }
);

export const selectLoading = createSelector(
  customerState,
  (state: ICustomerState) => {
    return state.loading;
  }
);
