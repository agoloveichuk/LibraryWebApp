import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, catchError, of, tap, throwError } from 'rxjs';
import { environment } from '../../environments/environment';
import { UserForAuthentication } from './models/user-for-authentication.model';
import { UserForRegistration } from './models/user-for-registration.model';
import { Token } from './models/token.model';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private apiUrl = environment.apiUrl;
  private userTokenKey = 'userToken';

  constructor(private http: HttpClient) {}

  public register(user: UserForRegistration): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/authentication`, user).pipe(
      tap(() => {
        // After successful registration, automatically log in the user
        const userForAuth: UserForAuthentication = {
          username: user.userName, // Use the username from the registration form
          password: user.password, // Use the password from the registration form
        };

        this.login(userForAuth).subscribe(
          () => {
            console.log('Automatic login successful after registration');
          },
          (error) => {
            console.error('Automatic login failed after registration', error);
          }
        );
      })
    );
  }

  public login(userForAuth: UserForAuthentication): Observable<any> {
    return this.http.post<Token>(`${this.apiUrl}/authentication/login`, userForAuth).pipe(
      tap((response : Token) => {
        const accessToken = response.accessToken;
        const refreshToken = response.refreshToken;

        localStorage.setItem('accessToken', accessToken);
        localStorage.setItem('refreshToken', refreshToken);
      })
    );
  }

  public logout(): void {
    localStorage.removeItem('accessToken');
    localStorage.removeItem('refreshToken');
  }

  public isLoggedIn(): boolean {
    return !!localStorage.getItem('accessToken');
  }

  public refreshToken(): Observable<Token | null> {
    const refreshToken = localStorage.getItem('refreshToken');
    if (!refreshToken) {
      // No refresh token available, user should re-login
      return of(null); // Return an observable that emits null
    }

    return this.http.post<Token>(`${this.apiUrl}/api/token/refresh`, { refreshToken }).pipe(
      tap((response: Token) => {
        localStorage.setItem(this.userTokenKey, response.accessToken);
      }),
      catchError((error) => {
        // Failed to refresh the token or no refresh token available, log the user out
        this.logout();
        return throwError(() => new Error('Authentication failed'))
      })
    );
  }
}
