import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup, Validators, FormControl } from '@angular/forms';
@Component({
  selector: 'app-login-register',
  templateUrl: './login-register.component.html',
  styleUrls: ['./login-register.component.sass']
})
export class LoginRegisterComponent implements OnInit {
  @Output() OnCloseDialogClick: EventEmitter<any> = new EventEmitter();
  isLogin = true;
  isRegister = false;

  isLastStep = false;

  formLoginGroup = new FormGroup({
    login: new FormControl('', Validators.required),
    password: new FormControl('', Validators.required),
  });

  formRegisterGroup = new FormGroup({
    name: new FormControl('', Validators.required),
    sername: new FormControl('', Validators.required),
    email: new FormControl('', Validators.required),
    phone: new FormControl('', Validators.required),
    password: new FormControl('', Validators.required),
    repeatPassword: new FormControl('', Validators.required),
  });

  constructor() { }

  ngOnInit() {
  }

  logIn() {
    console.log(this.formLoginGroup.get('login').value);
    console.log(this.formLoginGroup.get('password').value);
  }

  /** Завершити реєстрацію */
  completeRegister() {
    alert('Welcome!');
    this.OnCloseDialogClick.emit();
  }

  /** Закрити форму */
  closeDialog() {
    this.OnCloseDialogClick.emit();
  }

  /** Зміна типу авторизації: логін/реєстрація */
  singInChange(type: string) {
    switch (type) {
      case 'login':
      this.isLogin = true;
      this.isRegister = false;
        break;
      case 'register':
      this.isLogin = false;
      this.isRegister = true;
        break;
    }
  }

  /** Перейти до останнього етапу реєстрації */
  toLastStep(isLast: boolean) {
    this.isLastStep = isLast;
  }
}
