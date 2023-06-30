import { Component, Input, OnInit } from '@angular/core';
import { eventsTableItem } from 'src/app/models/features/event-models';
import { EventService } from 'src/app/services/event.service';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.scss'],
  providers: [EventService],
})
export class EventsComponent {
  constructor() {}
}
