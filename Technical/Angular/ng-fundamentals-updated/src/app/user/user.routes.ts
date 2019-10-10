import { Routes } from '@angular/router';
import { ProfileComponent } from './userProfile/userProfile.component';
import { LoginComponent } from './login/login.component';
export const userProfileRoutes: Routes = [
    { path: 'profile', component: ProfileComponent},
    { path: 'login', component: LoginComponent },
    { path: '', redirectTo: 'profile', pathMatch: 'full' },
];
