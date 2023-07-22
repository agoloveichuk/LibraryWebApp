import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
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
      userName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(8)]],
      repeatPassword: ['', Validators.required],
      roles: [[]]
    }, {
      validators: this.passwordMatchValidator
    });
  }

  passwordMatchValidator = (formGroup: FormGroup): ValidationErrors | null => {
    const password = formGroup.get('password')?.value;
    const repeatPassword = formGroup.get('repeatPassword')?.value;
  
    return password === repeatPassword ? null : { passwordMismatch: true };
  };

  onSubmit(): void {
    if (this.registerForm.valid) {
      const password = this.registerForm.get('password')?.value;
      const repeatPassword = this.registerForm.get('repeatPassword')?.value;
  
      if (password !== repeatPassword) {
        this.errorMessage = 'Passwords do not match.';
        return;
      }

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