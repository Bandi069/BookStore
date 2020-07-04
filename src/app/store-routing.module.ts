import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthenticationGuard } from './authentication.guard';
import { StoreDashboardComponent } from './Component/store-dashboard/store-dashboard.component';
import { BooksShowComponent } from './Component/books-show/books-show.component';
import { LoginPageComponent } from './Component/login-page/login-page.component';
import { BooksDisplayComponent } from './Component/books-display/books-display.component';
import { RegistrationComponent } from './Component/registration/registration.component';

const routes: Routes = [
  {
    path: 'register',
    component: RegistrationComponent
  },
  {
    path: '',
    redirectTo: "/loginpage",
    pathMatch: 'full'
  },
  {
    path: 'loginpage',
    component: LoginPageComponent
  },
   {
    path:'storedashboard',
    component:StoreDashboardComponent,
    canActivate:[AuthenticationGuard],
    children:[
      {
        path:'',
      component:BooksDisplayComponent
     },
     {
      path:'bookShow',
    component:BooksShowComponent
   }
    ]},
  
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class StoreRoutingModule { }

