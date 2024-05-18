import { Injectable } from '@angular/core';
import { environment } from '../environments/environment.development';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class BuggyService {

  baseUrl = environment.apiUrl
  constructor(private http: HttpClient) { }

  getErrorNotFound() {
    return this.http.get(this.baseUrl + 'buggy/notfound');
  }
  getServerError() {
    return this.http.get(this.baseUrl + 'buggy/servererror');
  }
  getBadRequest() {
    return this.http.get(this.baseUrl + 'buggy/badrequest');
  }
  getvalidationError() {
    return this.http.get(this.baseUrl + 'buggy/badrequest/five');
  }
}
