import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ICustomerView } from '../models/customerView';
import { CustomerTypes } from '../models/enums/customerTypes.enum';
import { ICustomer } from './../models/customer';
@Injectable()
export class CustomerHelper {
  static toCustomerView(customers: ICustomer[]): ICustomerView[] {
    if (!customers) return [];

    return customers.map((customer: ICustomer) => {
      return <ICustomerView>{
        id: customer.id,
        customerName: customer.customerName,
        customerType:
          customer.customerType === 'IndividualUser'
            ? CustomerTypes.IndividualUser
            : CustomerTypes.Organization,
        website: customer.website,
        status: customer.status === false ? 'Inactive' : 'Active',
      };
    });
  }
}
