import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { HttpServiceService } from './http-service.service';

@Injectable({
  providedIn: 'root'
})

export class BookServiceService {

  constructor(
    private http: HttpClient,
    private httpservice: HttpServiceService
  ) { }

  header = {
    headers: new HttpHeaders()
      .set('Authorization', `Bearer ${localStorage.token}`)
  }
 getAllBooks(){
   return this.httpservice.getAllBooksRequest();
 }
  bookupdate(updateBookData) {
    return this.httpservice.updateBookRequest(updateBookData);
  }

  bookCount() {
    debugger;
    return this.httpservice.getBookCountRequest();
  }
}
