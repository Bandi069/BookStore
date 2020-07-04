import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatIconModule } from '@angular/material';
import { MatDialogRef, MatDialogModule } from '@angular/material/dialog';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatFormFieldModule } from '@angular/material/form-field';
import {FlexLayoutModule} from "@angular/flex-layout";
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { BidiModule } from '@angular/cdk/bidi';
import { MatButtonModule } from '@angular/material/button';
import { NgxSpinnerModule } from "ngx-spinner"; 
import {MatSelectModule} from '@angular/material/select';
import {MatPaginatorModule} from '@angular/material/paginator';


@NgModule({
  declarations: [],
  imports: [
    FormsModule, 
    ReactiveFormsModule ,
    BrowserAnimationsModule,
    MatIconModule,
    BidiModule,
    FlexLayoutModule,
    MatDialogModule,
    MatButtonModule,
    MatInputModule,
    MatSnackBarModule,
    MatFormFieldModule,
    MatCardModule,
    NgxSpinnerModule,
    MatSelectModule,
    MatPaginatorModule
  ],
  exports:[
    CommonModule,
    FormsModule, 
    ReactiveFormsModule ,
    BrowserAnimationsModule,
    MatIconModule,
    BidiModule,
    FlexLayoutModule,
    MatDialogModule,
    MatButtonModule,
    MatInputModule,
    MatSnackBarModule,
    MatFormFieldModule,
    MatCardModule,
    NgxSpinnerModule,
    MatSelectModule,
    MatPaginatorModule
  ]
})
export class MaterialModulesModule { }
