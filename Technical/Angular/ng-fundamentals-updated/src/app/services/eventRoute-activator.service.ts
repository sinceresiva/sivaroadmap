import { ActivatedRouteSnapshot, CanActivate } from '@angular/router';
import { Router } from '@angular/Router';
import { Injectable } from '@angular/core';
import { EventDataService } from './eventdata.service';

@Injectable()
export class EventRouteActivatorService implements CanActivate {
    constructor(private eventService: EventDataService, private router: Router) {

    }

    canActivate(route: ActivatedRouteSnapshot): any {
        const eventExists = !!this.eventService.getEvent(+route.params['id']); // + denotes cast to a number
        if (!eventExists) {
            this.router.navigate(['404']);
        }
        return (eventExists);
    }

}
