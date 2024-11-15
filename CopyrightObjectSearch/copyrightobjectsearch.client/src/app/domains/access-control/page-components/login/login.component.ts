import { Component, OnInit } from '@angular/core';
import { AppService } from '../../../../app.service';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { LoginRq } from '../../server-proxy/dto/LoginRq';
import { LoginRsp } from '../../server-proxy/dto/LoginRsp';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: [
    './login.component.css',
    '../../../../app.component.css'
  ]
})
export class LoginComponent implements OnInit {

  loginFormControl    : FormControl = new FormControl('SUPERADMIN');
  passwordFormControl : FormControl = new FormControl('&SUPERADMIN$');
  
  errorText = '';

  constructor(
    private appService: AppService,
    private http: HttpClient,
    private router: Router,
  ) {
  }

  ngOnInit() {
  }

  login() {
    this.errorText = '';
    const rq: LoginRq = {
      login    : this.loginFormControl.value    ,
      password : this.passwordFormControl.value ,
    };
    this.http.post<LoginRsp>('http://localhost:5235/api/AccessControl/Login', rq)
        .subscribe({
          next: response => {
            if (response.errorText !== '') {
              this.errorText = response.errorText;
            }
            else {
              this.appService.userId              = response.id;
              this.appService.userLogin           = response.login;
              this.appService.userName            = response.name;
              this.appService.userIsUserAdmin     = response.roleIds.findIndex(x => x === 1) != -1;
              this.appService.userIsTaskAdmin     = response.roleIds.findIndex(x => x === 2) != -1;
              this.appService.userIsTaskOperator  = response.roleIds.findIndex(x => x === 3) != -1;
              this.appService.userIsMultyRole = response.roleIds.length > 1;

              if (this.appService.userIsTaskOperator) {
                this.router.navigateByUrl('domains/search-engine/page-components/external-objects-list');
              }
              else if (this.appService.userIsTaskAdmin) {
                this.router.navigateByUrl('domains/task-management/page-components/task-management');
              }
              else if (this.appService.userIsUserAdmin) {
                this.router.navigateByUrl('domains/user-administration/page-components/user-administration');
              }
            }
          },
          error: error => {
            this.errorText = error.message;
          }
        });
    // this.appService.userId = 1;
    // this.router.navigateByUrl('domains/user-administration/page-components/user-administration');

  }

  onLogin() {
    this.login();
  }

  isErrorDivVisible(): boolean {
    return this.errorText !== '';
  }
}
