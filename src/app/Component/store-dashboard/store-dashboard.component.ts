import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';


@Component({
  selector: 'app-store-dashboard',
  templateUrl: './store-dashboard.component.html',
  styleUrls: ['./store-dashboard.component.scss']
})
export class StoreDashboardComponent implements OnInit {

  constructor(
    private route:Router,
    private spinner: NgxSpinnerService
    ) { }

  ngOnInit() {
    this.spinner.show();
    setTimeout(() => {
      this.spinner.hide();
    }, 5000);
  }
  logout(){
    localStorage.clear();
    this.route.navigate(['/loginpage']);
  }
  debugger;
  home(){
    this.route.navigate(['/storedashboard']);
  }
}
