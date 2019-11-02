import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/Router';

@Component({
  templateUrl: './userProfile.component.html'
})
export class ProfileComponent implements OnInit {

  profileFormGp: FormGroup;

  /**
   *
   */
  constructor(private authSvc: AuthService, private router: Router) {
  }

  ngOnInit(): void {
    const firstNameCntl = new FormControl(this.authSvc.currentUser.firstName);
    const lastNameCntrl = new FormControl(this.authSvc.currentUser.lastName);
    this.profileFormGp = new FormGroup({
      firstName: firstNameCntl,
      lastName: lastNameCntrl
    });
  }

  saveProfile(profileForm) {
    const formValues = profileForm.value;
    this.authSvc.updateCurrentUser(formValues.firstName, formValues.lastName);
    this.router.navigate(['events']);
  }
  cancel() {
    this.router.navigate(['events']);
  }
}
