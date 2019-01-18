import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-main-app',
  templateUrl: './main-app.component.html',
  styleUrls: ['./main-app.component.sass']
})
export class MainAppComponent implements OnInit {

  singInDialogVisible = false;

  constructor() { }

  ngOnInit() {
  }

  signInClick() {
    this.singInDialogVisible = true;
  }

  closeSignInForm() {
    this.singInDialogVisible = false;
  }

}
