import { Injectable } from '@angular/core';
import { IEmployee } from './employee';
import {HttpClient, HttpErrorResponse} from '@angular/common/http'
import {Observable, throwError } from 'rxjs';
import {catchError, tap} from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})
export class EmployeeService
{
    private employeeServiceBaseUrl='https://localhost:44392/Employee';

    private employeeByIdPatch='/GetById?Id='

    constructor(private http: HttpClient)
    {

    }
    getEmployees(): Observable<IEmployee[]>
    {
        return this.http.get<IEmployee[]>(this.employeeServiceBaseUrl).pipe(
            tap(data=>console.log('All: '+ JSON.stringify(data))),
            catchError(this.handleError)
        );
    }
    getEmployeeById(idEmployee:string): Observable<IEmployee>
    {
        const path =this.employeeServiceBaseUrl+this.employeeByIdPatch+idEmployee
        return this.http.get<IEmployee>(path).pipe(
            tap(data=>console.log('All: '+ JSON.stringify(data))),
            catchError(this.handleError)
        );
    }
    private handleError(err: HttpErrorResponse)
    {
        let errorMessage='';
        if(err.error instanceof ErrorEvent)
        {
            errorMessage=`An error ocurred: ${err.error.message}`;
        }
        else
        {
            errorMessage =`Server returned code: ${err.status}, error message is: ${err.message}`    
        }

        console.error(errorMessage);
        return throwError(errorMessage);
    }
}