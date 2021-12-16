import { customerReducers } from './customer/customer.reducer';
import { routerReducer } from '@ngrx/router-store';
import { ActionReducerMap } from '@ngrx/store';
import { IAppState } from './app.state';

export const appReducers: ActionReducerMap<IAppState, any> = {
  router: routerReducer,
  customers: customerReducers,
};
