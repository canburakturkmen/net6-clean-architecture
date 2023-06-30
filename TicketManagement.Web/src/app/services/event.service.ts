import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { catchError, map, throwError } from 'rxjs';
import { eventLeadData } from '../models/api/event-models';
import { eventsTableItem } from '../models/features/event-models';

const EVENT_SERVICE_URL = 'https://localhost:7143/api/events';

@Injectable({
  providedIn: 'root',
})
export class EventService {
  constructor(private http: HttpClient) {}

  getEvents() {
    return this.http.get<eventLeadData[]>(EVENT_SERVICE_URL, {}).pipe(
      map((responseData) => {
        const eventTableItemArray: eventsTableItem[] = [];
        for (const eventLead of responseData) {
          eventTableItemArray.push(eventLead);
        }
        return eventTableItemArray;
      }),
      catchError((errorRes) => {
        return throwError(() => new Error(errorRes));
      })
    );
  }
}
