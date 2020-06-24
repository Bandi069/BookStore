import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RegistrationComponent } from './Component/registration/registration.component';
import { LoginPageComponent } from './Component/login-page/login-page.component';

const routes: Routes = [
  {path:'register',component:RegistrationComponent},
  {path:'loginpage',component:LoginPageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
