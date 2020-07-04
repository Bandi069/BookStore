import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class HttpServiceService {
SwaggarLink:'environment.Url';
  constructor(private http: HttpClient) { }
  header = {
    headers: new HttpHeaders()
      .set('Authorization', `Bearer ${localStorage.token}`)
  }
  PostHttpRequest() {
  }

  getBookCountRequest() {
    debugger;
    return this.http.get(environment.Url + 'api/Cart/getBookCount', this.header);
  }

  getAllBooksRequest() {
    return this.http.get(environment.Url + 'api/AddBook', this.header);
  }

  updateBookRequest(updateData) {
    return this.http.put(environment.Url + 'api/AddBook', updateData, this.header);
  }
  
}