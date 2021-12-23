import { AddEditCustomerComponent } from './views/customers/add-edit-customer/add-edit-customer.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListCustomersComponent } from './views/customers/list-customers/list.customers.component';

const routes: Routes = [
  { path: '', component: ListCustomersComponent, pathMatch: 'full' },
  {
    path: 'add-edit-customer/:id',
    component: AddEditCustomerComponent,
    pathMatch: 'full',
  },
  {
    path: 'add-edit-customer',
    component: AddEditCustomerComponent,
    pathMatch: 'full',
  },
  { path: 'customers', component: ListCustomersComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
