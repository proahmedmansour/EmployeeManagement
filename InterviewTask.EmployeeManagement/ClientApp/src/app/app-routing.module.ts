import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { AddDepartmentComponent } from './departments/list/add-department/add-department.component';
import { DepartmentListComponent } from './departments/list/department-list/department-list.component';
import { MainComponent } from './main/main.component';

const routes: Routes = [
  { path: 'departments', component: DepartmentListComponent },
  { path: 'departments/add', component: AddDepartmentComponent },
  // { path: 'lead-details/:leadId', component: LeadDetailsComponent },
  // { path: 'book-details/:bookId', component: BookDetailsComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
