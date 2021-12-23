import { CustomerService } from 'src/app/services/customer.service';
import { ICustomer } from './../../models/customer';
import {
  GetCustomer,
  ECustomerActions,
  GetCustomersSuccess,
  GetCustomerSuccess,
  GetCustomers,
  AddNewCustomer,
  AddNewCustomerSuccess,
  EditCustomer,
  EditCustomerSuccess,
  DeleteCustomer,
  DeleteCustomerSuccess,
} from './customer.actions';
import { Injectable } from '@angular/core';
import { Actions, Effect, ofType } from '@ngrx/effects';
import { switchMap, map } from 'rxjs/operators';
import { IAppState } from '../app.state';
import { Store } from '@ngrx/store';
import { of } from 'rxjs';

@Injectable()
export class CustomerEffects {
  @Effect()
  getCustomers$ = this._actions$.pipe(
    ofType<GetCustomers>(ECustomerActions.GetCustomers),
    map((action: any) => action.payload),
    switchMap(() => this._customerService.getCustomers()),
    switchMap((customers: ICustomer[]) =>
      of(new GetCustomersSuccess(customers))
    )
  );

  @Effect()
  getCustomer$ = this._actions$.pipe(
    ofType<GetCustomer>(ECustomerActions.GetCustomer),
    map((action: any) => action.payload),
    switchMap((customerId: Number) =>
      this._customerService.getCustomerById(customerId)
    ),
    switchMap((customer: ICustomer) => of(new GetCustomerSuccess(customer)))
  );

  @Effect()
  addNewCustomer$ = this._actions$.pipe(
    ofType<AddNewCustomer>(ECustomerActions.AddNewCustomer),
    map((action: any) => action.payload),
    switchMap((customer: ICustomer) =>
      this._customerService
        .addNewCustomer(customer)
        .pipe(
          switchMap((customer: ICustomer) =>
            of(new AddNewCustomerSuccess(customer))
          )
        )
    )
  );

  @Effect()
  editCustomer$ = this._actions$.pipe(
    ofType<EditCustomer>(ECustomerActions.EditCustomer),
    map((action: any) => action.payload),
    switchMap((customer: ICustomer) =>
      this._customerService
        .editCustomer(customer)
        .pipe(
          switchMap((customer: ICustomer) =>
            of(new EditCustomerSuccess(customer))
          )
        )
    )
  );

  @Effect()
  deleteCustomer$ = this._actions$.pipe(
    ofType<DeleteCustomer>(ECustomerActions.DeleteCustomer),
    map((action: any) => action.payload),
    switchMap((customerId: Number) =>
      this._customerService
        .deleteCustomer(customerId)
        .pipe(
          switchMap((response: Boolean) =>
            of(new DeleteCustomerSuccess(response))
          )
        )
    )
  );

  constructor(
    private _customerService: CustomerService,
    private _actions$: Actions,
    private _store: Store<IAppState>
  ) {}
}
