import { Component } from "@angular/core";
import { MatDialog } from '@angular/material/dialog';
import { LoginFormComponent } from '../../auth/login-form/login-form.component';
import { RegisterFormComponent } from "../../auth/register-form/register-form.component";
import { AuthService } from "src/app/shared/auth.service";

@Component({
    selector: 'app-navbar',
    templateUrl: './navbar.component.html',
    styleUrls: ['./navbar.component.scss']
})

export class NavbarComponent {
    constructor(
        private dialog: MatDialog,
        private authService: AuthService
    ) {}

    openLoginDialog(): void {
        const dialogRef = this.dialog.open(LoginFormComponent, {
        width: '400px',
        });

        dialogRef.afterClosed().subscribe(result => {

        });
    }

    openRegisterDialog(): void {
        const dialogRef = this.dialog.open(RegisterFormComponent, {
          width: '400px',
        });
    
        dialogRef.afterClosed().subscribe(result => {

        });
    }

    public getUserName(): string | null {
      const token = localStorage.getItem('accessToken');
      if (token) {
        const payload = JSON.parse(atob(token.split('.')[1]));
        const username = payload['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'];
        return username;
      }
      return null;
    }

    public isLoggedIn(): boolean {
      return this.authService.isLoggedIn();
    }
  
    public onLogout(): void {
      this.authService.logout();
    }
}