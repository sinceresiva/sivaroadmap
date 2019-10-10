import { RouterModule } from '@angular/Router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProfileComponent } from './userProfile/userProfile.component';
import { userProfileRoutes } from './user.routes';
import { LoginComponent } from './login/login.component';

@NgModule({
  declarations: [
    ProfileComponent,
    LoginComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(userProfileRoutes)
  ],
  providers: [
  ]
})
export class UserModule { }

