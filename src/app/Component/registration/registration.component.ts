import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormControl, Validators } from '@angular/forms';
import { AccountService } from 'src/app/Service/account.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit {
  hide = true;
  constructor(private route: Router,private snackbar:MatSnackBar,private accountservice:AccountService) { }
 
  firstName = new FormControl('', [
    Validators.required, Validators.minLength(4), Validators.pattern('^[a-zA-Z]*'),]);
 
  lastName = new FormControl('', [
    Validators.required, Validators.minLength(4), Validators.pattern('^[a-zA-Z]*'),])

  email = new FormControl('', [
    Validators.required, Validators.email, Validators.pattern('^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$'),]);

  password = new FormControl('', [
    Validators.required, Validators.minLength(8),]);
     ngOnInit() {
  }
  registrationForm() {
   // debugger;
    let fname = new String(this.firstName.value);
    let lname = new String(this.lastName.value);
    let pwd = new String(this.password.value);
    if (fname.length >= 4 && lname.length >= 4 && pwd.length >= 8) {
     //debugger;

      const form = {
        firstName: this.firstName.value,
        lastName: this.lastName.value,
        email: this.email.value,
        password: this.password.value
      };
     // debugger;
      this.accountservice.registrationform(form).subscribe(
        (result) => {
         // debugger;
          const temp = JSON.stringify(result);
      const results = JSON.parse(temp);
         //debugger;
          this.snackbar.open('Register Successfull', 'Dismiss', { duration: 3000, horizontalPosition: 'start' });
          console.log('result :', results);
          this.route.navigate(['/loginpage']);
          // localStorage.setItem('FirstName', form.firstName);
          // localStorage.setItem('LastName', form.lastName);
        },
        (error) => {
         debugger;
          this.snackbar.open('Unsuccesful registration ', '', { duration: 4000, horizontalPosition: 'start' });
        });
    }
  }
}
