import { Action } from '@ngrx/store';

export enum ECustomerActions {
  GetCustomers = '[Customer] Get Customers',
  GetCustomersSuccess = '[Customer] Get Customers Success',
  GetCustomer = '[Customer] Get Customer',
  GetCustomerSuccess = '[Customer] Get Customer Success',
}

export class GetCustomers implements Action {
  public readonly type = ECustomerActions.GetCustomers;
}

export class GetCustomersSuccess implements Action {
  constructor(public payload: any = null) {}
  public readonly type = ECustomerActions.GetCustomersSuccess;
}

export class GetCustomer implements Action {
  public readonly type = ECustomerActions.GetCustomer;
}

export class GetCustomerSuccess implements Action {
  constructor(public payload: any = null) {}
  public readonly type = ECustomerActions.GetCustomerSuccess;
}

export type CustomerActions =
  | GetCustomers
  | GetCustomersSuccess
  | GetCustomer
  | GetCustomerSuccess;
