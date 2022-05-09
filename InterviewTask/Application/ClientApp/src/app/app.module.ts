import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DepartmentListComponent } from './departments/list/department-list/department-list.component';
import { MainComponent } from './main/main.component';
import { AddDepartmentComponent } from './departments/list/add-department/add-department.component';
// import { ServiceProxyModule } from 'src/shared/service-proxies/service-proxy.module';

@NgModule({
  declarations: [
    AppComponent,
    DepartmentListComponent,
    MainComponent,
    AddDepartmentComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    // ServiceProxyModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
