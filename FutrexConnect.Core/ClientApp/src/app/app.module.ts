import { CustomerService } from 'src/app/services/customer.service';
import { AppRoutingModule } from './app-routing.module';
import { environment } from './../environments/environment.prod';
import { appReducers } from './state/app.reducers';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { CustomerEffects } from './state/customer/customer.effects';
import { StoreRouterConnectingModule } from '@ngrx/router-store';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { ListCustomersComponent } from './views/customers/list-customers/list.customers.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { SideNavMenuComponent } from './components/side-nav-menu/side-nav-menu.component';
import { HeaderNavMenuComponent } from './components/header-nav-menu/header-nav-menu.component';
import { BreadcrumbComponent } from './components/breadcrumb/breadcrumb.component';
import { DataTablesModule } from 'angular-datatables';
import { MatTableModule } from '@angular/material/table';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatInputModule } from '@angular/material/input';
import { MatSortModule } from '@angular/material/sort';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatDialogModule } from '@angular/material/dialog';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { StatusIndicatorComponent } from './components/status-indicator/status-indicator.component';
import { TableActionsComponent } from './components/table-actions/table-actions.component';
import { AddEditCustomerComponent } from './views/customers/add-edit-customer/add-edit-customer.component';
import { MatOptionModule } from '@angular/material/core';
import { MatSelectModule } from '@angular/material/select';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatSnackBarModule } from '@angular/material/snack-bar';

import { DialogComponent } from './components/dialog/dialog.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ListCustomersComponent,
    SideNavMenuComponent,
    HeaderNavMenuComponent,
    BreadcrumbComponent,
    StatusIndicatorComponent,
    TableActionsComponent,
    AddEditCustomerComponent,
    DialogComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    StoreModule.forRoot(appReducers),
    EffectsModule.forRoot([CustomerEffects]),
    StoreRouterConnectingModule.forRoot({ stateKey: 'router' }),
    !environment.production ? StoreDevtoolsModule.instrument() : [],
    AppRoutingModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    DataTablesModule,
    MatTableModule,
    MatFormFieldModule,
    MatPaginatorModule,
    MatInputModule,
    MatSortModule,
    MatButtonModule,
    MatIconModule,
    MatOptionModule,
    MatSelectModule,
    MatExpansionModule,
    MatGridListModule,
    MatDialogModule,
    MatProgressBarModule,
    MatSnackBarModule,
  ],
  providers: [CustomerService],
  bootstrap: [AppComponent],
})
export class AppModule {}
