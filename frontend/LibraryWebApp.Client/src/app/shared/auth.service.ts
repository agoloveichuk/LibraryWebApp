import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';
import { environment } from '../../environments/environment';
import { User } from './models/user.model';
import { UserForAuthentication } from './models/user-for-authentication.model';

interface LoginResponse {
  accessToken: string;
  refreshToken: string;
}

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  public register(user: User): Observable<any> {
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
}
