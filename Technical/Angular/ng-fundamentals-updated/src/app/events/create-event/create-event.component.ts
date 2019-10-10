import { Component, OnInit } from '@angular/core';
import { ToastrService } from '../../services/toastr.service';
// import { Router } from '@angular/router';
import { Router } from '@angular/Router';
declare let toastr;

@Component({
  selector: 'app-create-event',
  templateUrl: './create-event.component.html',
  providers: [
    ToastrService
  ]
})
export class CreateEventComponent implements OnInit {
  /**
   *
   */
  isDirty: Boolean = true;
  constructor(private toastrService: ToastrService, private router: Router) {
  }
  ngOnInit() {
    console.log('Inside OnInit');
  }
  doCancel() {
    this.router.navigate(['events']);
  }
}
