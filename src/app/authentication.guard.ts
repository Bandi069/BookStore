import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, CanActivate, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthGuardServiceService } from './Service/auth-guard-service.service';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationGuard implements CanActivate {
  // canActivate():boolean{
  //   return true;
    
  // }
  constructor(private Authguardservice: AuthGuardServiceService, private router: Router) {}  
canActivate(): boolean {  
    if (this.Authguardservice.gettoken()) { 
      return true; 
       // this.router.navigateByUrl("/loginpage");  
    } 
    else{
      this.router.navigate(['loginpage']);
      return false;
    } 
   // return this.Authguardservice.gettoken();  
}  
}
