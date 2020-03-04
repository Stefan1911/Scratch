import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';
import { UserStore } from '../userStoreService';
@Injectable({
	providedIn: 'root'
})
export class LoginGuardService implements CanActivate {
  constructor(public userStore: UserStore, public router: Router) {}
  canActivate(): boolean {
    if (!this.userStore.isLogedIn) {
      this.router.navigate(['login']);
      return false;
    }
    return true;
  }
}