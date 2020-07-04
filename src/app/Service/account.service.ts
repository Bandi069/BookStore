import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  constructor(private http: HttpClient) { }
 // debugger;
  registrationform(values) {
   //debugger;
    return this.http.post(environment.Url + 'api/StoreAccount', values);
  }
  loginform(parm) {
   // debugger;
    return this.http.post<any>(environment.Url + 'api/StoreAccount/StoreLogin', parm);
  }
}
