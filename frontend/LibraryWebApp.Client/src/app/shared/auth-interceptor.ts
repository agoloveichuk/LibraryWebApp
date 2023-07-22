import { Injectable } from "@angular/core";
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from "@angular/common/http";
import { Observable, throwError } from "rxjs";
import { catchError, switchMap } from "rxjs";
import { AuthService } from "./auth.service";
import { Token } from "./models/token.model";

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  constructor(private authService: AuthService) {}

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    // Add the access token to the Authorization header
    const accessToken = localStorage.getItem('accessToken');
    if (accessToken) {
      request = request.clone({
        setHeaders: {
          Authorization: `Bearer ${accessToken}`,
        },
      });
    }

    return next.handle(request).pipe(
      catchError((error) => {
        // Check if the error is due to an expired access token (HTTP 401 Unauthorized)
        if (error.status === 401 && !request.url.includes('/api/token')) {
          // Try refreshing the access token
          return this.authService.refreshToken().pipe(
            switchMap((newToken: Token | null) => {
              if (newToken) {
                // Retry the original request with the new access token
                request = request.clone({
                  setHeaders: {
                    Authorization: `Bearer ${newToken.accessToken}`,
                  },
                });
                return next.handle(request);
              } else {
                // Failed to refresh the token or no refresh token available, log the user out
                this.authService.logout();
                return throwError('Authentication failed');
              }
            })
          );
        } else {
          // For other errors, just pass the error along
          return throwError(error);
        }
      })
    );
  }
}