import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/Router';
import { EventDataService } from 'src/app/services/eventdata.service';
import { IEvent } from 'src/app/shared/event.model';

@Component({
    templateUrl: './event-details.component.html',
    styles: [`
        .container { padding-left: 20px; padding-right: 20px },
        .event-image { max-height: 20px }
    `]
})
export class EventDetailsComponent implements OnInit {
    event: IEvent;
    constructor(private eventsService: EventDataService,
        private route: ActivatedRoute) {
    }
    ngOnInit() {
        this.event = this.eventsService.getEvent(+this.route.snapshot.params['id']);
        console.log(this.event.name);
    }
}
