import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Employee } from 'src/app/models/employee.model';
import { EmployeeService } from 'src/app/services/employee.service';


@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent {

  
  employees: Employee[]=[];

  EmployeeRequest: Employee = {
    surname: '',
    name: '',
    patronymic: '',
    birthday: new Date,
    dateOfEmployment: new Date,
    wages: 0,
    departament: '',
    idEmployee: 0,
    InState: true
  };

  constructor(private employeeService: EmployeeService, private router: Router) {}
 
 ngOnInit(): void {
  this.employeeService.getEmployees().subscribe({
    next: (employees) => {
      console.log(employees);
      this.employees = employees;
    },
    error: (response) => {
      console.log(response);
    }
  })
  }

  addEmployee() {
    this.employeeService.addEmployee(this.EmployeeRequest).subscribe(
      {
        next: (employee) => {
          this.employeeService.getEmployees().subscribe({
            next: (employees) => {
              console.log(employees);
              this.employees = employees;
            },
            error: (response) => {
              console.log(response);
            }
          })
        },
        error: (response) => {
          console.log(response);
        }
      });
}

getEmployee(employee: Employee) {
  this.EmployeeRequest = employee;
}

updateEmployee(EmployeeRequest: Employee) {
  this.employeeService.updateEmployee(this.EmployeeRequest).subscribe({
    next: (response) => {
      this.employeeService.getEmployees().subscribe({
        next: (employees) => {
          console.log(employees);
          this.employees = employees;
        },
        error: (response) => {
          console.log(response);
        }
      })
    }
  })
}

deleteEmployee(EmployeeRequest: Employee) {
  this.employeeService.deleteEmployee(this.EmployeeRequest).subscribe({
    next: (response) => {
      this.employeeService.getEmployees().subscribe({
        next: (employees) => {
          console.log(employees);
          this.employees = employees;
        },
        error: (response) => {
          console.log(response);
        }
      })
    }
  })
}
}