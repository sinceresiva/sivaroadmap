import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/Router';
import { AppComponent } from './app.component';
import { EventsListComponent } from './events/event-list/events-list.component';
import { EventThumbnailComponent } from './events/event-thumbnail/event-thumbnail.component';
import { CreateEventComponent } from './events/create-event/create-event.component';
import { NavBarComponent } from './nav/navbar.component';
import { EventDetailsComponent } from './events/event-details/event-details.component';
import { appRoutes } from './routes';
import { Error404Component } from './errors/404.component';
import { EventDataService } from './services/eventdata.service';
import { EventRouteActivatorService } from './services/eventRoute-activator.service';
import { EventDataResolver } from './services/eventdata.resolver.service';
import { CommonModule } from '@angular/common';
import { AuthService } from './user/services/auth.service';

@NgModule({
  declarations: [
    AppComponent,
    EventsListComponent,
    EventThumbnailComponent,
    EventDetailsComponent,
    NavBarComponent,
    CreateEventComponent,
    Error404Component
  ],
  imports: [
    BrowserModule,
    CommonModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [
    EventDataService,
    EventRouteActivatorService,
    EventDataResolver,
    {
      provide: 'canDeactivateCreateEventService',
      useValue: checkDirtyState
    },
    AuthService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

export function checkDirtyState(createEventComponent: CreateEventComponent) {
  if (createEventComponent.isDirty) {
    return window.confirm('Data not save. Do you want to continue?');
  }
  return true;
}
