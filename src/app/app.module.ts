import { BrowserModule } from '@angular/platform-browser';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { Routes,RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import {StoreRoutingModule} from './store-routing.module';
import { AppRoutingModule, routingComponents } from './app-routing.module';
import { AppComponent } from './app.component';
import { AccountService } from './Service/account.service';
import {AuthGuardServiceService} from './Service/auth-guard-service.service';
import { MaterialModulesModule} from './material-modules/material-modules.module';
import { BooksShowComponent } from './Component/books-show/books-show.component';

@NgModule({
  declarations: [
    AppComponent,
    routingComponents,
    BooksShowComponent,

  ],
  imports: [
    BrowserModule,
    MaterialModulesModule,
    StoreRoutingModule,
    AppRoutingModule,
    HttpClientModule,
    RouterModule.forRoot([])
  ],
  providers: [AccountService,AuthGuardServiceService],
  bootstrap: [AppComponent],
  schemas: [
    CUSTOM_ELEMENTS_SCHEMA,
  ]
})
export class AppModule { }
