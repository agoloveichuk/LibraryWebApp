import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { AuthService } from '../../../shared/auth.service';
import { UserForAuthentication } from 'src/app/shared/models/user-for-authentication.model';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.scss']
})
export class LoginFormComponent implements OnInit {
  loginForm!: FormGroup;
  errorMessage: string | null = null;

  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthService,
    private dialogRef: MatDialogRef<LoginFormComponent>
  ) { }

  ngOnInit(): void {
    this.initForm();
  }

  initForm(): void {
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  onSubmit(): void {
    if (this.loginForm.valid) {
      const username = this.loginForm.get('username')?.value;
      const password = this.loginForm.get('password')?.value;
      const userForAuth: UserForAuthentication = { username, password };

      this.authService.login(userForAuth).subscribe(
        response => {
          // Handle successful login here (e.g., store token, redirect, etc.)
          console.log('Login successful!', response);
          this.dialogRef.close();
        },
        error => {
          this.errorMessage = error.message; // Display the error message to the user
        }
      );
    }
  }

  onCancel(): void {
    this.dialogRef.close();
  }
}
