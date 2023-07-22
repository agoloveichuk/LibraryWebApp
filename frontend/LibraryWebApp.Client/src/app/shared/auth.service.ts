import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, catchError, of, tap, throwError } from 'rxjs';
import { environment } from '../../environments/environment';
import { UserForAuthentication } from './models/user-for-authentication.model';
import { UserForRegistration } from './models/user-for-registration.model';
import { Token } from './models/token.model';

interface LoginResponse {
  accessToken: string;
  refreshToken: string;
}

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private apiUrl = environment.apiUrl;
  private userTokenKey = 'userToken';

  constructor(private http: HttpClient) {}

  public register(user: UserForRegistration): Observable<any> {
    return this.http.post(`${this.apiUrl}/register`, user);
  }

  public login(userForAuth: UserForAuthentication): Observable<any> {
    return this.http.post<LoginResponse>(`${this.apiUrl}/authentication/login`, userForAuth).pipe(
      tap((response : LoginResponse) => {
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
        localStorage.setItem(this.userTokenKey, response.accessToken); // Store the new access token
      }),
      catchError((error) => {
        // Failed to refresh the token or no refresh token available, log the user out
        this.logout();
        return throwError('Authentication failed');
      })
    );
  }
}
