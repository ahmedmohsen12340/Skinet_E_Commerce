import { state } from '@angular/animations';
import { HttpErrorResponse, HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { NavigationExtras, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { catchError, throwError } from 'rxjs';



export const errorInterceptor: HttpInterceptorFn = (req, next) => {
  const router = inject(Router)
  const toasterService = inject(ToastrService);
  return next(req).pipe(
    catchError((err: HttpErrorResponse) => {
      if (err.status === 400) {
        if (err.error.errors) {
          throw err.error
        }
        else {
          toasterService.error(err.error.message, err.status.toString())
        }
      }
      if (err.status === 401) {
        toasterService.error(err.error.message, err.status.toString())
      }
      if (err.status === 404) {
        let navgationExtras: NavigationExtras = { state: { error: err.error } }
        router.navigateByUrl("notFound", navgationExtras)
      }
      if (err.status === 500) {
        let navgationExtras: NavigationExtras = { state: { error: err.error } }
        router.navigateByUrl("serverError", navgationExtras)
      }

      return throwError(() => new Error(err.message))
    })
  )
};
