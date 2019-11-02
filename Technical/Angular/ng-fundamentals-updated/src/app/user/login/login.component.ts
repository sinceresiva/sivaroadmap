import { Component } from '@angular/core';
import { Router } from '@angular/Router';
import { AuthService } from '../services/auth.service';


@Component({
    templateUrl: './login.component.html',
})
export class LoginComponent {
    userName: string;
    password: string;
    /**
     *
     */
    constructor(private authService: AuthService, private router: Router) {
    }
    login(loginForm) {
        if (!loginForm.invalid) {
            this.authService.loginUser(loginForm.value.userName, loginForm.value.password);
            this.router.navigate(['events']);
        }
    }
}
