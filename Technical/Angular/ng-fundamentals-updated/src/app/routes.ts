import { Routes, RouterModule } from '@angular/router';
import { EventsListComponent } from './events/event-list/events-list.component';
import { EventDetailsComponent } from './events/event-details/event-details.component';
import { CreateEventComponent } from './events/create-event/create-event.component';
import { Error404Component } from './errors/404.component';
import { EventRouteActivatorService } from './services/eventRoute-activator.service';
import { EventDataResolver } from './services/eventdata.resolver.service';
export const appRoutes: Routes = [
    { path: 'events', component: EventsListComponent, resolve: {events: EventDataResolver} },
    { path: 'events/new', component: CreateEventComponent, canDeactivate: ['canDeactivateCreateEventService']},
    { path: 'events/:id', component: EventDetailsComponent, canActivate: [EventRouteActivatorService] },
    { path: 'user', loadChildren: () => import('./user/user.module').then(m => m.UserModule) },
    // { path : 'user', loadChildren: () => UserModule },
    // { path: 'user', loadChildren: './user/user.module#UserModule' },
    { path: '404', component: Error404Component },
    { path: '', redirectTo: 'events', pathMatch: 'full' }
    // { path : 'user', loadChildren: () => UserModule }
    // { path: 'user', loadChildren: './user/user.module' }
    // { path: 'user', loadChildren: './user/user.module#UserModule' }, // ./user/user.module#UserModule
];
