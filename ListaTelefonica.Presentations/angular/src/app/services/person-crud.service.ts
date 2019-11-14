import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Person } from '../models/person';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class PersonCrudService {

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

  put(person): Observable<boolean> {
    const url = `${environment.urlService}`;
    return this.http.put<boolean>(url, person);
  }

  deleteId(id): Observable<boolean> {
    const url = `${environment.urlService}/${id}`;
    return this.http.delete<boolean>(url);
  }
}
