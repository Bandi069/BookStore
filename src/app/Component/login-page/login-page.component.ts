import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AccountService } from 'src/app/Service/account.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss']
})
export class LoginPageComponent implements OnInit {
  hide = true;
  constructor(
    private route: Router,
    private snackbar: MatSnackBar,
    private accountservice: AccountService,
    private spinner: NgxSpinnerService
  ) { }

  ngOnInit() {
    this.spinner.show();
    setTimeout(() => {
      this.spinner.hide();
    }, 3000);
  }
  email = new FormControl('', [
    Validators.required,
    Validators.minLength(12),
    Validators.maxLength(20),
    Validators.email,
    Validators.pattern(new RegExp('^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$')),
  ]);

  password = new FormControl('', [
    Validators.required,
    Validators.pattern(new RegExp('^[A-Za-z0-9._%+-]{8,16}$')),
//    Validators.pattern(new RegExp('^(?=.*[A-Za-z&._-])(?=.*\d)[A-Za-z0-9\d]{7,}$')),
    Validators.minLength(8),
    Validators.maxLength(16)]);

  emailErrorMessage() {
    return this.email.hasError('required') ? 'Enter an email' :
      this.email.hasError('email') ? 'Invalid email ' :
        this.email.hasError('minlength') ? 'Email should be min 12 characters' :
          this.email.hasError('maxlength') ? 'Email should be max 20 characters' :
            '';
  }
  passwordErrorMessage() {
    return this.password.hasError('required') ? 'Enter a password' :
      this.password.hasError('pattern') ? 'Password should be alphanumeric' :
        this.password.hasError('minlength') ? 'Password length min 8 characters' :
          this.password.hasError('maxlength') ? 'Password length max 16 characters' :
            '';
  }

  loginForm() {
    const loginData = {
      Email: this.email.value,
      Password: this.password.value,
    };
    this.accountservice.loginform(loginData).subscribe((response) => {
      // debugger;
      if (Response != null) {
        localStorage.setItem('Email', loginData.Email);
        localStorage.setItem('token', response['token']);
        this.snackbar.open('Login Successful', 'Dismiss',
         { duration: 3000, horizontalPosition: 'start' });
        this.route.navigate(['/storedashboard']);
      }
    },
      (error) => {
        // debugger;
        this.snackbar.open('Incorrect login credentials', 'Cancel',
         { duration: 4000, horizontalPosition: 'start' });
      });
  }
  
}
