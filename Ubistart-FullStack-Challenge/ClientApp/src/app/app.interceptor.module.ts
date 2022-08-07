import { Injectable, NgModule } from '@angular/core';

import {
  HttpEvent,
  HttpInterceptor,
  HttpHandler,
  HttpRequest,
} from '@angular/common/http';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { Observable } from 'rxjs';
import { LoginComponent } from './login/login.component';


@Injectable()
export class HttpsRequestInterceptor implements HttpInterceptor {
    intercept(
        req: HttpRequest<any>,
        next: HttpHandler,
    ): Observable<HttpEvent<any>> {
        
        var token = LoginComponent.getToken();
        var isAuthenticated = LoginComponent.getIsAuthenticated();
        const dupReq = req.clone({
            headers: req.headers.set('authorization', (isAuthenticated && token) ? 'Bearer ' + token : ''),
        });
        return next.handle(dupReq);
    }

}


@NgModule({
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: HttpsRequestInterceptor,
      multi: true,
    },
  ],
})

export class Interceptor { }