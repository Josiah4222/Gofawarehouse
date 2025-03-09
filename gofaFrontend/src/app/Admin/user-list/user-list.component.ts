import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {
  users: any[] = []; // All users fetched from the API
  filteredUsers: any[] = []; // Users after applying filters
  paginatedUsers: any[] = []; // Users to display on the current page
  isLoading = true;
  error: string | null = null;

  // Pagination variables
  currentPage = 1;
  itemsPerPage = 10; // Number of users per page
  totalPages = 1;

  // Filtering and search variables
  searchName: string = '';
  selectedRole: string = '';
  availableRoles: string[] = ['VHF', 'HF', 'Transit', 'Sparepart', 'Manager', 'Electronics']; // Example roles

  constructor(private authService: AuthService) {}

  ngOnInit(): void {
    this.loadUsers();
  }

  loadUsers(): void {
    this.isLoading = true;
    this.authService.getAllUsers().subscribe({
      next: (data: any[]) => {
        console.log('API Response:', data); // Log the API response
        this.users = data.map(user => ({
          ...user,
          username: user.username, // Ensure the `username` property is included
          role: user.roles?.join(', ') || 'N/A',
          isEditing: false,
          originalData: { ...user }
        }));
        console.log('Mapped Users:', this.users); // Log the mapped users
        this.applyFilters(); // Apply filters after loading users
        this.isLoading = false;
        this.error = null;
      },
      error: (error) => {
        console.error('Error fetching users:', error);
        this.error = 'Failed to load users. Please try again later.';
        this.isLoading = false;
      }
    });
  }


  // In UserListComponent
  deleteUser(user: any): void {
    if (!confirm(`Are you sure you want to delete user "${user.firstName} ${user.lastName}"?`)) {
      return; // Cancel deletion if the user cancels the confirmation dialog
    }
  
    this.authService.deleteUserByUsername(user.username).subscribe({
      next: (response) => {
        console.log('User deleted successfully:', response);
        // Remove the deleted user from the local list
        this.users = this.users.filter(u => u.username !== user.username);
        this.applyFilters(); // Reapply filters to update the paginated list
      },
      error: (error) => {
        console.error('Error deleting user:', error);
        alert('Failed to delete user. Please try again.');
      }
    });
  }

  // Apply filters based on search name and selected role
  applyFilters(): void {
    this.filteredUsers = this.users.filter(user => {
      const matchesName = user.firstName.toLowerCase().includes(this.searchName.toLowerCase()) ||
                          user.lastName.toLowerCase().includes(this.searchName.toLowerCase());
      const matchesRole = this.selectedRole ? user.role === this.selectedRole : true;
      return matchesName && matchesRole;
    });

    this.currentPage = 1; // Reset to the first page after applying filters
    this.totalPages = Math.ceil(this.filteredUsers.length / this.itemsPerPage);
    this.updatePaginatedUsers();
  }

  // Update the paginated users based on the current page
  updatePaginatedUsers(): void {
    const startIndex = (this.currentPage - 1) * this.itemsPerPage;
    const endIndex = startIndex + this.itemsPerPage;
    this.paginatedUsers = this.filteredUsers.slice(startIndex, endIndex);
  }

  // Go to the next page
  nextPage(): void {
    if (this.currentPage < this.totalPages) {
      this.currentPage++;
      this.updatePaginatedUsers();
    }
  }

  // Go to the previous page
  previousPage(): void {
    if (this.currentPage > 1) {
      this.currentPage--;
      this.updatePaginatedUsers();
    }
  }

  // Start editing a user
  startEditing(user: any): void {
    user.isEditing = true;
  }

  // Save edited user data
  saveUser(user: any): void {
    user.isEditing = false;
  
    // Update roles using the update-roles endpoint
    const roles = user.role.split(',').map((role: string) => role.trim()); // Convert role string to array
    this.authService.updateUserRoles(user.id, roles).subscribe({
      next: (response) => {
        console.log('User roles updated successfully:', response);
        // Update the original data
        user.originalData = { ...user };
      },
      error: (error) => {
        console.error('Error updating user roles:', error);
        // Revert to the original data if the update fails
        Object.assign(user, user.originalData);
      }
    });
  }

  // Cancel editing and revert to the original data
  cancelEditing(user: any): void {
    user.isEditing = false;
    Object.assign(user, user.originalData);
  }
}