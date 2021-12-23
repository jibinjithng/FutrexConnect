import { ICustomer } from 'src/app/models/customer';
import { Action } from '@ngrx/store';

export enum ECustomerActions {
  GetCustomers = '[Customer] Get Customers',
  GetCustomersSuccess = '[Customer] Get Customers Success',

  GetCustomer = '[Customer] Get Customer',
  GetCustomerSuccess = '[Customer] Get Customer Success',

  AddNewCustomer = '[Customer] Add New Customer',
  AddNewCustomerSuccess = '[Customer] Add New Customer Success',

  EditCustomer = '[Customer] Edit Customer',
  EditCustomerSuccess = '[Customer] Edit Customer Success',

  DeleteCustomer = '[Customer] Delete Customer',
  DeleteCustomerSuccess = '[Customer] Delete Customer Success',
}

export class GetCustomers implements Action {
  public readonly type = ECustomerActions.GetCustomers;
}

export class GetCustomersSuccess implements Action {
  constructor(public payload: any = null) {}
  public readonly type = ECustomerActions.GetCustomersSuccess;
}

export class GetCustomer implements Action {
  constructor(public payload: Number = null) {}
  public readonly type = ECustomerActions.GetCustomer;
}

export class GetCustomerSuccess implements Action {
  constructor(public payload: ICustomer = null) {}
  public readonly type = ECustomerActions.GetCustomerSuccess;
}

export class AddNewCustomer implements Action {
  constructor(public payload: ICustomer) {}
  public readonly type = ECustomerActions.AddNewCustomer;
}

export class AddNewCustomerSuccess implements Action {
  constructor(public payload: ICustomer) {}
  public readonly type = ECustomerActions.AddNewCustomerSuccess;
}

export class EditCustomer implements Action {
  constructor(public payload: ICustomer) {}
  public readonly type = ECustomerActions.EditCustomer;
}

export class EditCustomerSuccess implements Action {
  constructor(public payload: ICustomer) {}
  public readonly type = ECustomerActions.EditCustomerSuccess;
}

export class DeleteCustomer implements Action {
  constructor(public payload: Number) {}
  public readonly type = ECustomerActions.DeleteCustomer;
}

export class DeleteCustomerSuccess implements Action {
  constructor(public payload: Boolean) {}
  public readonly type = ECustomerActions.DeleteCustomerSuccess;
}

export type CustomerActions =
  | GetCustomers
  | GetCustomersSuccess
  | GetCustomer
  | GetCustomerSuccess
  | AddNewCustomer
  | AddNewCustomerSuccess
  | EditCustomer
  | EditCustomerSuccess
  | DeleteCustomer
  | DeleteCustomerSuccess;
