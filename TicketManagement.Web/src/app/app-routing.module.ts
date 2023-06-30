import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { WelcomeComponent } from './shared/welcome/welcome.component';
import { EventsComponent } from './features/events/events.component';
import { CreateEventComponent } from './features/events/create-event/create-event.component';
import { EventDashboardComponent } from './features/events/event-dashboard/event-dashboard.component';

const routes: Routes = [
  { path: '', component: WelcomeComponent, children: [] },
  {
    path: 'events',
    component: EventsComponent,
    children: [
      {
        path: '',
        component: EventDashboardComponent,
      },
      {
        path: 'new',
        component: CreateEventComponent,
      },
    ],
  },
  { path: 'categories', component: EventsComponent, children: [] },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
