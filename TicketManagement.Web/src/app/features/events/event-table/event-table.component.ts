import { Component, Input, OnInit } from '@angular/core';
import { eventsTableItem } from 'src/app/models/features/event-models';
import { EventService } from 'src/app/services/event.service';

@Component({
  selector: 'app-event-table',
  templateUrl: './event-table.component.html',
  styleUrls: ['./event-table.component.scss'],
})
export class EventTableComponent implements OnInit {
  eventsList: eventsTableItem[] = [];

  constructor(private eventService: EventService) {}
  ngOnInit(): void {
    this.eventService.getEvents().subscribe((events) => {
      this.eventsList = events;
    }),
      (error: Error) => {
        console.log(error);
      };
  }
}
