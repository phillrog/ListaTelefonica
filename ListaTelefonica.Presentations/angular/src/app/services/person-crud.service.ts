import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Person } from '../models/person';
import { Observable, Subject, BehaviorSubject } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class PersonCrudService {
  public subject = new Subject<any>();

  constructor(private http : HttpClient) { }

  getAll(): Observable<Person> {
    const url = environment.urlService;
    return this.http.get<Person>(url);
  }

  getById(id): Observable<Person> {
    const url = `${environment.urlService}/${id}`;
    return this.http.get<Person>(url);
  }

  post(person): Observable<Person> {
    const url = `${environment.urlService}`;
    return this.http.post<Person>(url, person);
  }

  put(person): Observable<any> {
    const url = `${environment.urlService}`;
    return this.http.put<Person>(url, person);
  }

  delete(id): Observable<any> {
    const url = `${environment.urlService}/${id}`;
    return this.http.delete<Person>(url);
  }
}
