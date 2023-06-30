import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SideNavComponent } from './side-nav/side-nav.component';
import { HttpClientModule } from '@angular/common/http';
import { MainHeaderComponent } from './shared/main-header/main-header.component';
import { WelcomeComponent } from './shared/welcome/welcome.component';
import { EventTableComponent } from './features/events/event-table/event-table.component';
import { EventsComponent } from './features/events/events.component';
import { CreateEventComponent } from './features/events/create-event/create-event.component';
import { EventDashboardComponent } from './features/events/event-dashboard/event-dashboard.component';

@NgModule({
  declarations: [
    AppComponent,
    MainHeaderComponent,
    EventsComponent,
    SideNavComponent,
    WelcomeComponent,
    EventTableComponent,
    CreateEventComponent,
    EventDashboardComponent,
  ],
  imports: [BrowserModule, AppRoutingModule, HttpClientModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
