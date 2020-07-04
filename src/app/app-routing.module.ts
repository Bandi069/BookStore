import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {StoreRoutingModule} from './store-routing.module';
import { LoginPageComponent } from './Component/login-page/login-page.component';
import { StoreDashboardComponent } from './Component/store-dashboard/store-dashboard.component';
import { PageNotFoundComponent } from './Component/page-not-found/page-not-found.component';
import { AuthenticationGuard } from './authentication.guard';
import { RegistrationComponent } from './Component/registration/registration.component';
import { BooksDisplayComponent } from './Component/books-display/books-display.component';
import { BooksShowComponent } from './Component/books-show/books-show.component';

const routes: Routes = [
  { 
    path: '', 
    redirectTo: "/loginpage",
     pathMatch: 'full'
 },  
  {
    path:'loginpage',
    component:LoginPageComponent
  },
 
  {
    path:'**',
    component:PageNotFoundComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
export const routingComponents=[LoginPageComponent,RegistrationComponent,
  StoreDashboardComponent,PageNotFoundComponent,BooksDisplayComponent]
