import { CustomerActions, ECustomerActions } from './customer.actions';
import { ICustomer } from './../../models/customer';
import { Action } from '@ngrx/store';
import { ICustomerState, initialCustomerState } from './customer.state';

export const customerReducers = (
  state = initialCustomerState,
  action: CustomerActions
): ICustomerState => {
  switch (action.type) {
    case ECustomerActions.GetCustomersSuccess:
      return {
        ...state,
        customers: action.payload,
      };
    case ECustomerActions.GetCustomerSuccess:
      return {
        ...state,
        customers: action.payload,
      };
    default:
      return state;
  }
};
