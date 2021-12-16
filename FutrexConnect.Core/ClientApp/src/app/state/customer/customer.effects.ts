import { CustomerService } from 'src/app/services/customer.service';
import { ICustomer } from './../../models/customer';
import {
  GetCustomer,
  ECustomerActions,
  GetCustomersSuccess,
  GetCustomerSuccess,
  GetCustomers,
} from './customer.actions';
import { Injectable } from '@angular/core';
import { Actions, Effect, ofType } from '@ngrx/effects';
import { select } from '@ngrx/core';
import { switchMap, map, withLatestFrom } from 'rxjs/operators';
import { IAppState } from '../app.state';
import { Store } from '@ngrx/store';
import { of } from 'rxjs';
import { selectCustomerList } from './customer.selectors';

@Injectable()
export class CustomerEffects {
  //   @Effect()
  //   getUser$ = this._actions$.pipe(
  //     ofType<GetCustomer>(ECustomerActions.GetCustomer),
  //     map((action: any) => action.payload),
  //     withLatestFrom(this._store.pipe(select(selectCustomerList))),
  //     switchMap((id: any, customers: any) => {
  //       const selectedUser = customers.filter((user) => user.id === +id)[0];
  //       return of(new GetCustomersSuccess(selectedUser));
  //     })
  //   );

  @Effect()
  getCustomers$ = this._actions$.pipe(
    ofType<GetCustomers>(ECustomerActions.GetCustomers),
    map((action: any) => action.payload),
    switchMap(() => this._customerService.getCustomers()),
    switchMap((customers: ICustomer[]) => of(new GetCustomerSuccess(customers)))
  );

  constructor(
    private _customerService: CustomerService,
    private _actions$: Actions,
    private _store: Store<IAppState>
  ) {}
}
