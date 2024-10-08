import { Component, OnInit } from '@angular/core';
import { AppService } from '../../../../app.service';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: [
    './login.component.css',
    '../../../../app.component.css'
  ]
})
export class LoginComponent implements OnInit {
  constructor(
    private appService: AppService,
    private http: HttpClient,
    private router: Router,
  ) {
  }

  ngOnInit() {
  }

  onApply() {
    this.appService.userId = 1;
    this.router.navigateByUrl('domains/user-administration/page-components/user-administration');
  }
}
