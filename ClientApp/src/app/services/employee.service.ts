import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Employee } from 'src/app/models/employee.model';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  
  constructor(private http: HttpClient) { }
  employeeURl='https://localhost:44323/api/employees';

  getEmployees(): Observable<Employee[]>{
    return this.http.get<Employee[]>(this.employeeURl);
  }

  addEmployee(addEmployeeRequest: Employee): Observable<Employee> {
    return this.http.post<Employee>(this.employeeURl, addEmployeeRequest);
  }

  getEmployee(idEmployee: string): Observable<Employee>{
    return this.http.get<Employee>(this.employeeURl +'/'+ idEmployee);
  }

  updateEmployee(updateRequest: Employee): Observable<Employee>{
    return this.http.put<Employee>(this.employeeURl + "/" + updateRequest.idEmployee, updateRequest);
  }

  deleteEmployee(deleteRequest: Employee): Observable<Employee>{
    return this.http.post<Employee>(this.employeeURl + "/" + deleteRequest.idEmployee, deleteRequest);
  }
}
