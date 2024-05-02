import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from '../services/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit{
  public _router;
  loggedIn: boolean = false;
  model: any = {};

  ngOnInit(): void {
  }

  constructor(public router: Router, private accountService: AccountService) {
    this._router = router;
  }

  login() {
    this.accountService.login(this.model).subscribe({
      next: response => {
        console.log(response);
        this.loggedIn = true;
        this._router.navigate(['home']);
      },
      error: error => console.log(error)
    });
  }
  
  loginViaGoogle() {
    
  }
}
