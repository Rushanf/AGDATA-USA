import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { Contact } from '../models/contact.model';

@Injectable({
  providedIn: 'root'
})
export class ContactService {
    private contactsUrl = 'https://localhost:7138/api/ContactInformation';  // URL to web api
    private httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };

    constructor(private http: HttpClient) { }

    /** GET contacts from the server */
    getContacts(): Observable<Contact[]> {
      var abc =  this.http.get<any>(this.contactsUrl)
        .pipe(
          catchError(this.handleError<any>('getContacts', []))
        );
        return abc;
    }

    /** GET contact by id */
    getContact(id: number): Observable<Contact> {
      const url = `${this.contactsUrl}/${id}`;
      return this.http.get<Contact>(url).pipe(
        catchError(this.handleError<Contact>(`getContact id=${id}`))
      );
    }

    /** POST: add a new contact to the server */
    addContact(contact: Contact): Observable<Contact> {
      return this.http.post<Contact>(this.contactsUrl, contact, this.httpOptions).pipe(
        catchError(this.handleError<Contact>('addContact'))
      );
    }

    /** patch: update the contact on the server */
    updateContact(contact: Contact): Observable<any> {
      return this.http.patch(this.contactsUrl, contact, this.httpOptions).pipe(
        catchError(this.handleError<any>('updateContact'))
      );
    }

    /** DELETE: delete the contact from the server */
    deleteContact(id: number): Observable<Contact> {
      const url = `${this.contactsUrl}?id=${id}`;
      return this.http.delete<Contact>(url, this.httpOptions).pipe(
        catchError(this.handleError<Contact>('deleteContact'))
      );
    }

    private handleError<T>(operation = 'operation', result?: T) {
      return (error: any): Observable<T> => {
        console.error(error); // log to console instead
        return of(result as T);
      };
    }
}
