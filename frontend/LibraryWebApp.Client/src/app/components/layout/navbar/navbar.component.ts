import { Component } from "@angular/core";
import { MatDialog } from '@angular/material/dialog';
import { LoginFormComponent } from '../../auth/login-form/login-form.component';

@Component({
    selector: 'app-navbar',
    templateUrl: './navbar.component.html',
    styleUrls: ['./navbar.component.scss']
})

export class NavbarComponent {
    constructor(private dialog: MatDialog) {}

    openLoginDialog(): void {
        const dialogRef = this.dialog.open(LoginFormComponent, {
        width: '400px', // Adjust the width as needed
        });

        dialogRef.afterClosed().subscribe(result => {
        // Handle any actions after the dialog is closed (if needed)
        });
    }
}