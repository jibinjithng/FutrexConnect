import { ICustomer } from '../../../models/customer';
import { selectCustomerList } from '../../../state/customer/customer.selectors';
import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { select, Store } from '@ngrx/store';
import { IAppState } from '../../../state/app.state';
import { GetCustomers } from '../../../state/customer/customer.actions';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ICustomerView } from '../../../models/customerView';
import { CustomerHelper } from '../../../helper/customer.helper';

@Component({
  selector: 'app-list-customers',
  templateUrl: './list-customers.component.html',
})
export class ListCustomersComponent {
  //customers: ICustomer[];
  customers: MatTableDataSource<ICustomerView>;

  displayedColumns: string[] = [
    'id',
    'customerName',
    'customerType',
    'website',
    'status',
    'action',
  ];
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  constructor(private _store: Store<IAppState>, private _router: Router) {
    this._store.dispatch(new GetCustomers());
    this._store.pipe(select(selectCustomerList)).subscribe((data) => {
      this.customers = new MatTableDataSource(
        CustomerHelper.toCustomerView(data)
      );
      this.customers.paginator = this.paginator;
      this.customers.sort = this.sort;
    });
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.customers.filter = filterValue.trim().toLowerCase();

    if (this.customers.paginator) {
      this.customers.paginator.firstPage();
    }
  }

  addEditCustomer(customerId) {
    const path =
      customerId === 0
        ? '/add-edit-customer'
        : '/add-edit-customer/' + customerId;
    this._router.navigate([path]);
  }
}
