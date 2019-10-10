import { Injectable } from '@angular/core';
import { Resolve } from '@angular/router';
import { EventDataService } from './eventdata.service';
import { map } from 'rxjs/operators';
@Injectable()
export class EventDataResolver implements Resolve<any> {
    constructor(private eventDataService: EventDataService) {

    }
    resolve() {
        return this.eventDataService.getEvents().pipe(map(events => events));
    }
}

