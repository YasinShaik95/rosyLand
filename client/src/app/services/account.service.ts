import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map } from 'rxjs';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl: string = 'https://localhost:5001/api/';
  private currentUSerSource = new BehaviorSubject<User | null>(null);
  currentUser$ = this.currentUSerSource.asObservable();

  constructor(private http: HttpClient) { }
  
  login(model: any) {
    return this.http.post<User>(this.baseUrl + 'account/login', model).pipe(
      map((response: User) => {
        const user = response;
        if (user) {
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUSerSource.next(user);
        }
      })
    );
  }

  setCurrentUser(user : User) {
    this.currentUSerSource.next(user);
  }

  logout() {
    localStorage.removeItem('user');
    this.currentUSerSource.next(null);
  }
}
