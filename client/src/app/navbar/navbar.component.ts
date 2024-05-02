import { Component, OnInit } from '@angular/core';
import { AccountService } from '../services/account.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent implements OnInit {
  searchString: string | undefined;
  loggedIn: boolean = false;

  constructor(private accountService:AccountService){}
  ngOnInit(): void {
    this.getCurrentUser();
  }

  getCurrentUser() {
    this.accountService.currentUser$.subscribe({
      next: user => this.loggedIn = !!user,
      error: error => console.log(error)
    });
  }

  search() {
    
  }

  logout() {
    this.accountService.logout();
  }

}
