import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent implements OnInit {
  searchString: string | undefined;
  loggedIn: boolean = false;
  constructor(){}
  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }

  search() {
    
  }

}
