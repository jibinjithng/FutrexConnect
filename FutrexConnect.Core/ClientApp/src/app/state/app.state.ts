import {
  ICustomerState,
  initialCustomerState,
} from './customer/customer.state';
import { RouterReducerState } from '@ngrx/router-store';

export interface IAppState {
  router?: RouterReducerState;
  customerState: ICustomerState;
}

export const initialAppState: IAppState = {
  customerState: initialCustomerState,
};

export function getInitialState(): IAppState {
  return initialAppState;
}
