import {
  CustomerActions,
  ECustomerActions,
  GetCustomer,
} from './customer.actions';
import { ICustomer } from './../../models/customer';
import { Action } from '@ngrx/store';
import { ICustomerState, initialCustomerState } from './customer.state';

export const customerReducers = (
  state = initialCustomerState,
  action: CustomerActions
): ICustomerState => {
  switch (action.type) {
    case ECustomerActions.GetCustomers:
      return {
        ...state,
        loading: true,
        error: null,
      };
    case ECustomerActions.GetCustomersSuccess:
      return {
        ...state,
        loading: false,
        error: null,
        customers: action.payload,
      };
    case ECustomerActions.GetCustomer:
      return {
        ...state,
        loading: true,
        error: null,
        selectedCustomerId: action.payload,
      };
    case ECustomerActions.GetCustomerSuccess:
      return {
        ...state,
        loading: false,
        error: null,
        selectedCustomer: action.payload,
      };
    case ECustomerActions.AddNewCustomer:
      return {
        ...state,
        loading: true,
        error: null,
      };
    case ECustomerActions.AddNewCustomerSuccess:
      return {
        ...state,
        loading: false,
        error: null,
        selectedCustomer: action.payload,
      };
    case ECustomerActions.EditCustomer:
      return {
        ...state,
        loading: true,
        error: null,
      };
    case ECustomerActions.EditCustomerSuccess:
      return {
        ...state,
        loading: false,
        error: null,
        selectedCustomer: action.payload,
      };
    case ECustomerActions.DeleteCustomer:
      return {
        ...state,
        loading: true,
        error: null,
      };
    case ECustomerActions.DeleteCustomerSuccess:
      return {
        ...state,
        loading: false,
        error: null,
      };
    default:
      return state;
  }
};
