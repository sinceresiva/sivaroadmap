import { Component, OnInit } from '@angular/core';
import { ToastrService } from '../../services/toastr.service';
import { ActivatedRoute } from '@angular/Router';
import { IEvent } from '../../shared/event.model';

declare let toastr;
@Component({
  selector: 'app-events-list',
  templateUrl: './events-list.component.html',
  providers: [
    ToastrService
  ]

})
export class EventsListComponent implements OnInit {
  /**
   *
   */
  events: IEvent[] = [];
  constructor(private toastrService: ToastrService, private activatedRoute: ActivatedRoute) {
  }
  ngOnInit() {
    this.events = this.activatedRoute.snapshot.data['events']; // Gets the events list from the resolver.
  }
  thumbnailButtonClicked = (event) => {
    console.log(event);
    this.toastrService.success('Clicked');
  }

  handleClickEventForThumbnail(eventName: string) {
    this.toastrService.success(eventName);
  }
}
