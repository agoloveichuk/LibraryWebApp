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
        width: '400px', // Adjust the width as needed
        });

        dialogRef.afterClosed().subscribe(result => {
        // Handle any actions after the dialog is closed (if needed)
        });
    }

    openRegisterDialog(): void {
        const dialogRef = this.dialog.open(RegisterFormComponent, {
          width: '400px', // Adjust the width as needed
        });
    
        dialogRef.afterClosed().subscribe(result => {
          // Handle any actions after the dialog is closed (if needed)
        });
    }

    public getUserName(): string | null {
      // Retrieve the username from the token or any other user information you have stored
      // For simplicity, I'm assuming you stored the username in the JWT payload.
      // Replace 'username' with the actual property name from your JWT payload.
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