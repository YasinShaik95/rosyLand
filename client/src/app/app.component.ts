import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AccountService } from './services/account.service';
import { User } from './models/user';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  title = 'rosyLand'; 

  constructor(private http: HttpClient, private accounService:AccountService) {
    
  }
  ngOnInit(): void {
    this.setCurrentUser();
  }

  setCurrentUser() {
    //const user: User = JSON.parse(localStorage.getItem('user'));
    const userString = localStorage.getItem('user');
    if (!userString) return; 
    const user: User = JSON.parse(userString);
    this.accounService.setCurrentUser(user);
  }
}
