import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ICustomer } from './../models/customer';
@Injectable()
export class CustomerService {
  customersURL = `${environment.apiUrl}/customer`;

  constructor(private _http: HttpClient) {}

  getCustomers(): Observable<ICustomer[]> {
    return this._http.get<ICustomer[]>(this.customersURL);
  }

  getCustomerById(customerId: Number): Observable<ICustomer> {
    var url = this.customersURL + '/' + customerId;
    return this._http.get<ICustomer>(url);
  }

  addNewCustomer(customer: ICustomer): Observable<ICustomer> {
    return this._http.post<ICustomer>(this.customersURL, customer);
  }

  editCustomer(customer: ICustomer): Observable<ICustomer> {
    return this._http.put<ICustomer>(this.customersURL, customer);
  }

  deleteCustomer(customerId: Number): Observable<any> {
    var url = this.customersURL + '/' + customerId;
    return this._http.delete<Number>(url);
  }
}
