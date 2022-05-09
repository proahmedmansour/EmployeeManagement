import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from "rxjs";
// import { ApiServiceProxy, DepartmentListDto } from 'src/shared/service-proxies/service-proxies';

@Component({
  selector: 'app-department-list',
  templateUrl: './department-list.component.html',
  styleUrls: ['./department-list.component.css']
})
export class DepartmentListComponent implements OnInit, OnDestroy {
  // departments: DepartmentListDto[] = [];
  // sub: Subscription;

  constructor() { }

  ngOnInit(): void {
    this.getDepartments();
  }

  
  getDepartments(): void {
    // this.showMainSpinner();
    // this.sub = 
    // this.apiService
    //     .departmentsGet()
    //     .subscribe(
    //         res => {
    //             // this.departments = res;
    //             // this.hideMainSpinner();
    //         },
    //         err => {
    //           alert(err)
    //             // this.hideMainSpinner();
    //             // this.errorAlert(err);
    //         }
    //     );
}

ngOnDestroy(): void {
  // if (this.sub != undefined) this.sub.unsubscribe();
}

}
