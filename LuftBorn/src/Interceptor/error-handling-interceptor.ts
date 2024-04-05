import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpErrorResponse, HttpHandler, HttpRequest, HttpEvent } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Router } from '@angular/router';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  constructor(private router: Router) {}

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>>{;
    return next.handle(req).pipe(
      catchError((error: HttpErrorResponse) => {
        let errorMessage = 'An Error occured';
        if (error.status == 401) {
            errorMessage='Session Timedout please login again';
            localStorage.removeItem('token');
          this.router.navigate(['/login']);
        }
        else if(error.status==404){
          this.router.navigate(['/not-found']);
        }
       else if (error.error instanceof ErrorEvent) {
          errorMessage = 'An Error occured';
        } 
        else {
          errorMessage = error.error.message || 'An Error occured';
        }
        

        return throwError({
          body: error.error.body,
          code: error.status,
          status: false,
          message: errorMessage
        });
      })
    );
  }
}