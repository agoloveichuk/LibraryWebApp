import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { AuthService } from '../../../shared/auth.service';

@Component({
  selector: 'app-register-form',
  templateUrl: './register-form.component.html',
  styleUrls: ['./register-form.component.scss']
})
export class RegisterFormComponent implements OnInit {
  registerForm!: FormGroup;
  errorMessage: string | null = null;

  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthService,
    private dialogRef: MatDialogRef<RegisterFormComponent>
  ) { }

  ngOnInit(): void {
    this.initForm();
  }

  initForm(): void {
    this.registerForm = this.formBuilder.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      userName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(8)]],
      roles: [[]]
    });
  }

  onSubmit(): void {
    if (this.registerForm.valid) {
      const user = this.registerForm.value;

      this.authService.register(user).subscribe(
        response => {
          console.log('Registration successful!', response);
          this.dialogRef.close();
        },
        error => {
          this.errorMessage = error.message;
        }
      );
    }
  }

  onCancel(): void {
    this.dialogRef.close();
  }
}