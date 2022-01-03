import { DeleteCustomer } from './../../../state/customer/customer.actions';
import {
  selectCustomerList,
  selectError,
  selectLoading,
} from '../../../state/customer/customer.selectors';
import { Component, ViewChild } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { select, Store } from '@ngrx/store';
import { IAppState } from '../../../state/app.state';
import { GetCustomers } from '../../../state/customer/customer.actions';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ICustomerView } from '../../../models/customerView';
import { CustomerHelper } from '../../../helper/customer.helper';
import { IDialogData } from 'src/app/models/dialogData';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { DialogComponent } from 'src/app/components/dialog/dialog.component';
import { DialogTypes } from 'src/app/models/enums/dialogTypes';
import { take, takeWhile } from 'rxjs/operators';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-list-customers',
  templateUrl: './list-customers.component.html',
})
export class ListCustomersComponent {
  customers: MatTableDataSource<ICustomerView>;
  isLoading$: Boolean;
  error$: any;

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

  constructor(
    private _store: Store<IAppState>,
    private _router: Router,
    private _route: ActivatedRoute,
    public dialog: MatDialog,
    private _snackBar: MatSnackBar
  ) {
    this._store.pipe(select(selectLoading)).subscribe((isLoading: Boolean) => {
      this.isLoading$ = isLoading;
    });
    this._store.pipe(select(selectError)).subscribe((error: any) => {
      this.error$ = error;
    });

    this._store.dispatch(new GetCustomers());
    this._store.pipe(select(selectCustomerList)).subscribe((data) => {
      if (data) {
        const constomersViewData = data.map((customer) =>
          CustomerHelper.toCustomerView(customer)
        );
        this.customers = new MatTableDataSource(constomersViewData);
        this.customers.paginator = this.paginator;
        this.customers.sort = this.sort;
      }
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
        ? 'add-edit-customer'
        : 'add-edit-customer/' + customerId;
    this._router.navigate([path], { relativeTo: this._route });
  }

  confirmDeleteCustomer(customerId) {
    const dialogData: IDialogData = {
      title: 'Customer',
      content: 'Are you sure you want to delete selected record?',
      dialogType: DialogTypes.Confirm,
    };
    const dialogRef = this.dialog.open(DialogComponent, {
      width: '350px',
      data: dialogData,
    });
    dialogRef.afterClosed().subscribe((result: any) => {
      if (result === 'yes') {
        this.deleteCustomer(customerId);
      }
    });
  }

  deleteCustomer(customerId: Number) {
    this._store.dispatch(new DeleteCustomer(customerId));
    this._store
      .pipe(select(selectLoading))
      .pipe(takeWhile((isLoading: Boolean) => isLoading === true, true))
      .subscribe((isLoading: Boolean) => {
        if (!isLoading && !this.error$) {
          this._store.dispatch(new GetCustomers());
          this._snackBar.open('Customer record deleted', 'Dismiss', {
            duration: 3000,
          });
        }
      });
  }
}
