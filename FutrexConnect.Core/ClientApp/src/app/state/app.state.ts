import {
  ICustomerState,
  initialCustomerState,
} from './customer/customer.state';
import { RouterReducerState } from '@ngrx/router-store';

export interface IAppState {
  router?: RouterReducerState;
  customers: ICustomerState;
}

export const initialAppState: IAppState = {
  customers: initialCustomerState,
};

export function getInitialState(): IAppState {
  return initialAppState;
}
