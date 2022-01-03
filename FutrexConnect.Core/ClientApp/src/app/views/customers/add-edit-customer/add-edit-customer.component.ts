import { ICustomer } from 'src/app/models/customer';
import { IDialogData } from './../../../models/dialogData';
import { DialogComponent } from './../../../components/dialog/dialog.component';
import {
  selectCustomer,
  selectError,
  selectLoading,
} from './../../../state/customer/customer.selectors';
import {
  AddNewCustomer,
  EditCustomer,
  GetCustomer,
} from './../../../state/customer/customer.actions';
import { ICustomerView } from './../../../models/customerView';
import { ICity } from './../../../models/city';
import { IState } from './../../../models/state';
import { ICountry } from './../../../models/country';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { select, Store } from '@ngrx/store';
import { takeWhile } from 'rxjs/operators';

import { IAppState } from 'src/app/state/app.state';
import { CustomerHelper } from 'src/app/helper/customer.helper';
import { MatDialog } from '@angular/material/dialog';
import { DialogTypes } from 'src/app/models/enums/dialogTypes';

@Component({
  selector: 'app-add-edit-customer',
  templateUrl: './add-edit-customer.component.html',
  styleUrls: ['./add-edit-customer.component.css'],
})
export class AddEditCustomerComponent implements OnInit {
  formGroup: FormGroup;
  countries: ICountry[];
  states: IState[];
  cities: ICity[];

  isLoading$: Boolean;
  error$: any;

  constructor(
    private formBuilder: FormBuilder,
    private _router: Router,
    private _route: ActivatedRoute,
    private _store: Store<IAppState>,
    public dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.initForm();

    //To be changed to dynamic data binding from api
    this.countries = [
      {
        id: 1,
        countryCode: 'DXB',
        countryName: 'United Arab Emirates',
        isActive: true,
      },
      {
        id: 2,
        countryCode: 'IND',
        countryName: 'India',
        isActive: true,
      },
    ];
    this.states = [
      {
        id: 1,
        stateCode: 'DXB',
        stateName: 'Dubai',
        isActive: true,
        countryId: 1,
      },
      {
        id: 2,
        stateCode: 'MH',
        stateName: 'Maharashtra',
        isActive: true,
        countryId: 2,
      },
    ];
    this.cities = [
      {
        id: 1,
        cityCode: 'DXB',
        cityName: 'Dubai',
        isActive: true,
        stateId: 1,
      },
      {
        id: 2,
        cityCode: 'BOM',
        cityName: 'Mumbai',
        isActive: true,
        stateId: 2,
      },
    ];
  }

  initForm() {
    const emailregex: RegExp =
      /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

    this.formGroup = this.formBuilder.group({
      id: [],
      customerName: [null, Validators.required],
      customerType: [null, Validators.required],
      website: [],

      contactDetailsId: [],
      email: [null, [Validators.required, Validators.pattern(emailregex)]],
      mobilePhone: [null, Validators.required],
      officePhone: [null, Validators.required],

      customerAddressDetailsId: [],
      address1: [null, Validators.required],
      address2: [],
      pincode: [null, Validators.required],
      cityId: [null, Validators.required],
      stateId: [null, Validators.required],
      countryId: [null, Validators.required],
    });
    this.getCustomerDetails();

    this._store.pipe(select(selectLoading)).subscribe((isLoading: Boolean) => {
      this.isLoading$ = isLoading;
    });
  }

  setForm(customerView: ICustomerView) {
    if (customerView) {
      this.formGroup.setValue({
        id: customerView.id,
        customerName: customerView.customerName,
        customerType: customerView.customerType,
        website: customerView.website,

        contactDetailsId: customerView.contactDetailsId,
        email: customerView.email,
        mobilePhone: customerView.mobilePhone,
        officePhone: customerView.officePhone,

        customerAddressDetailsId: customerView.customerAddressDetailsId,
        address1: customerView.address1,
        address2: customerView.address2,
        pincode: customerView.pincode,
        cityId: customerView.cityId,
        stateId: customerView.stateId,
        countryId: customerView.countryId,
      });
    }
  }

  getCustomerDetails() {
    this._route.params.subscribe((params) => {
      const customerId: Number = params.id;
      if (customerId > 0) {
        this._store.dispatch(new GetCustomer(customerId));
        this._store.pipe(select(selectCustomer)).subscribe((customer) => {
          const customerView = CustomerHelper.toCustomerView(customer);
          this.setForm(customerView);
        });
      }
    });
  }

  cancel() {
    this._router.navigate(['/settings/customers/']);
  }

  submitForm() {
    const customer = CustomerHelper.toCustomer(
      this.formGroup.value as ICustomerView
    );

    this._store
      .pipe(select(selectError))
      .pipe(takeWhile((error: any) => error !== null, true))
      .subscribe((error: any) => {
        this.error$ = error;
      });
    if (customer.id > 0) {
      this.updateCustomer(customer);
    } else {
      this.addNewCustomer(customer);
    }
  }

  addNewCustomer(customer: ICustomer) {
    this._store.dispatch(new AddNewCustomer(customer));
    this._store
      .pipe(select(selectLoading))
      .pipe(takeWhile((isLoading: Boolean) => isLoading === true, true))
      .subscribe((isLoading: Boolean) => {
        if (!isLoading && !this.error$) {
          const dialogData: IDialogData = {
            title: 'Customer',
            content: 'New customer added successfully',
            dialogType: DialogTypes.Alert,
          };
          this.showDialog(dialogData);
        }
      });
  }

  updateCustomer(customer: ICustomer) {
    this._store.dispatch(new EditCustomer(customer));
    this._store
      .pipe(select(selectLoading))
      .pipe(takeWhile((isLoading: Boolean) => isLoading === true, true))
      .subscribe((isLoading: Boolean) => {
        if (!isLoading && !this.error$) {
          const dialogData: IDialogData = {
            title: 'Customer',
            content: 'Customer updated successfully',
            dialogType: DialogTypes.Alert,
          };
          this.showDialog(dialogData);
        }
      });
  }

  showDialog(dialogData: IDialogData) {
    const dialogRef = this.dialog.open(DialogComponent, {
      width: '350px',
      data: dialogData,
    });

    dialogRef.afterClosed().subscribe((result) => {
      this._router.navigate(['/settings/customers']);
    });
  }
}
