import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ICustomer } from './../models/customer';
@Injectable()
export class CustomerService {
  usersUrl = `${environment.apiUrl}/customer`;

  constructor(private _http: HttpClient) {}

  getCustomers(): Observable<ICustomer[]> {
    return this._http.get<ICustomer[]>(this.usersUrl);
  }
}
