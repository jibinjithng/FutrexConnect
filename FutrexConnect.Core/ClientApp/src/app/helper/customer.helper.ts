import { ICustomerView } from './../models/customerView';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CustomerTypes } from '../models/enums/customerTypes.enum';
import { ICustomer } from './../models/customer';
@Injectable()
export class CustomerHelper {
  static toCustomerView(customer: ICustomer): ICustomerView {
    if (!customer) return null;

    const customerContactDetails = customer.customerContactDetails[0];
    const customerAddressDetails = customer.customerAddressDetails[0];
    return <ICustomerView>{
      id: customer.id,
      customerName: customer.customerName,
      customerType:
        customer.customerType === 'IndividualUser'
          ? CustomerTypes.IndividualUser
          : CustomerTypes.Organization,
      website: customer.website,
      status: customer.status === false ? 'Inactive' : 'Active',

      contactDetailsId: customerContactDetails?.id,
      mobilePhone: customerContactDetails?.mobilePhone,
      email: customerContactDetails?.email,
      officePhone: customerContactDetails?.officePhone,

      customerAddressDetailsId: customerAddressDetails?.id,
      address1: customerAddressDetails?.address1,
      address2: customerAddressDetails?.address2,
      countryId: customerAddressDetails?.countryId,
      stateId: customerAddressDetails?.stateId,
      cityId: customerAddressDetails?.cityId,
      pincode: customerAddressDetails?.pincode,
    };
  }

  static toCustomer(customerView: ICustomerView): ICustomer {
    return {
      id: customerView.id,
      customerName: customerView.customerName,
      customerType:
        customerView.customerType === CustomerTypes.IndividualUser ? '' : '',
      website: customerView.website,
      status: customerView.status === 'Active',
      customerContactDetails: [
        {
          id: customerView?.contactDetailsId,
          mobilePhone: customerView?.mobilePhone,
          email: customerView?.email,
          officePhone: customerView?.officePhone,
          customerId: customerView?.id,
        },
      ],

      customerAddressDetails: [
        {
          id: customerView?.customerAddressDetailsId,
          customerId: customerView?.id,
          address1: customerView?.address1,
          address2: customerView?.address2,
          countryId: customerView?.countryId,
          stateId: customerView?.stateId,
          cityId: customerView?.cityId,
          pincode: customerView?.pincode,
        },
      ],
    };
  }
}
