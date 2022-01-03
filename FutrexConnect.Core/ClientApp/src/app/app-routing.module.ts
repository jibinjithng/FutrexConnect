import { AddEditCustomerComponent } from './views/customers/add-edit-customer/add-edit-customer.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListCustomersComponent } from './views/customers/list-customers/list.customers.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: '/settings/customers',
    pathMatch: 'full',
    data: { title: 'Settings' },
  },
  {
    path: 'settings/customers',
    data: {
      parent: {
        title: 'Settings',
        iconUrl: '../../assets/icons/Settings2.svg',
      },
      title: 'Customers',
    },
    children: [
      {
        path: '',
        component: ListCustomersComponent,
        pathMatch: 'full',
        data: { title: 'All Customers', parent: null },
      },
      {
        path: 'add-edit-customer',
        component: AddEditCustomerComponent,
        data: { title: 'Add New Customer', parent: null },
      },
      {
        path: 'add-edit-customer/:id',
        component: AddEditCustomerComponent,
        data: { title: 'Edit Customer', parent: null },
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
