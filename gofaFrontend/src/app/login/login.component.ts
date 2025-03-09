import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  loginForm: FormGroup;
  errorMessage: string = ''; // To display backend errors

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router
  ) {
    this.loginForm = this.fb.group({
      username: [
        '',
        [
          Validators.required,
          Validators.pattern(/^[a-zA-Z0-9_-]{3,16}$/), // Username validation regex
        ],
      ], // Username format validation
      password: ['', [Validators.required, Validators.minLength(6)]], // Minimum length of 6
    });
  }

  /**
   * Handles form submission.
   */
  onSubmit(): void {
    if (this.loginForm.invalid) {
      return;
    }

    const { username, password } = this.loginForm.value;

    this.authService.login(username, password).subscribe(
      (response) => {
        const role = localStorage.getItem('role');
        if (!role) {
          console.error('No role found after login');
          this.errorMessage = 'Failed to retrieve user role. Please try again.';
          return;
        }

        this.redirectUser(role);
      },
      (error: any) => {
        console.error('Login failed:', error);
        this.errorMessage = 'Invalid credentials or server error. Please try again.';
      }
    );
  }

  /**
   * Redirects the user based on their role.
   * @param role The user's role.
   */
  redirectUser(role: string): void {
    switch (role) {
      case 'VHF':
        this.router.navigate(['/register-item']);
        break;
      case 'Sparepart':
        this.router.navigate(['/register-item']);
        break;
      case 'Electronics':
        this.router.navigate(['/register-item']);
        break;
      case 'HF':
        this.router.navigate(['/register-item']);
        break;
      case 'Transit':
        this.router.navigate(['/transit/received-items']);
        break;
      default:
        this.router.navigate(['/default-dashboard']); // Default route
    }
  }
}