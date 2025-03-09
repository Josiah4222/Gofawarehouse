import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent {
  registerForm: FormGroup;
  isLoading = false; // Loading state for form submission
  allowedRoles = ['VHF', 'HF', 'Transit', 'Sparepart', 'Electronics', 'Manager']; // Allowed roles

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router
  ) {
    this.registerForm = this.fb.group({
      firstName: ['', [Validators.required, Validators.minLength(2)]],
      lastName: ['', [Validators.required, Validators.minLength(2)]],
      username: [
        '',
        [
          Validators.required,
          Validators.pattern(/^[a-zA-Z0-9_-]{3,16}$/), // Username validation regex
        ],
      ],
      password: ['', [Validators.required, Validators.minLength(6)]],
      role: ['VHF', Validators.required], // Default role is "VHF"
    });
  }

  /**
   * Handles form submission.
   */
  onSubmit(): void {
    if (this.registerForm.invalid) {
      this.markFormGroupTouched(this.registerForm); // Mark all fields as touched to display validation errors
      return;
    }

    if (this.isLoading) return; // Prevent duplicate submissions
    this.isLoading = true;

    const registerDto = this.registerForm.value;

    this.authService.register(registerDto).subscribe({
      next: (response) => {
        console.log('Registration successful:', response);
        alert('Registration successful! Please log in.');
        this.router.navigate(['/login']); // Redirect to login page after successful registration
      },
      error: (error) => {
        console.error('Registration failed:', error);
        alert('Registration failed. Please check your input and try again.');
      },
      complete: () => {
        this.isLoading = false; // Reset loading state
      },
    });
  }

  /**
   * Marks all form controls as touched to display validation errors.
   * @param formGroup The form group to mark as touched.
   */
  private markFormGroupTouched(formGroup: FormGroup): void {
    Object.values(formGroup.controls).forEach((control) => {
      control.markAsTouched();

      if (control instanceof FormGroup) {
        this.markFormGroupTouched(control); // Recursively mark nested form groups
      }
    });
  }
}