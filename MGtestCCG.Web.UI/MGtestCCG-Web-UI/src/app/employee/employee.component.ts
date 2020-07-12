import { Component, OnInit } from '@angular/core';
import { IEmployee } from './employee';
import { EmployeeService } from './employee.service';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {

  ngOnInit(): void 
  {
    this.listFilter='';
  }

 findEmployee(): void{
   this.employees=[];
   if(this.listFilter==='')
   {
    this.employeeService.getEmployees().subscribe({
      next: employees=>
       {
         this.employees=employees
       },
      error: err => this.errorMessage=err
    });  
   }
   else
   {
    this.employeeService.getEmployeeById(this.listFilter).subscribe({
      next: employees=>
       {
         this.employees.push(employees);
       },
      error: err => this.errorMessage=err
    });  
   }
 }

 _listFilter: string;
    get listFilter():string{
      return this._listFilter;
    }

    set listFilter(value: string){
      this._listFilter=value;
    }
 
   errorMessage: string;

   employees: IEmployee[] = [];
   filteredEmploye: IEmployee[];


constructor(private employeeService: EmployeeService){}

     

}
