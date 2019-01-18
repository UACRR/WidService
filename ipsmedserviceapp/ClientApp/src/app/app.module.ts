import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { DialogModule, WindowModule, DialogsModule } from '@progress/kendo-angular-dialog';
import { ButtonsModule } from '@progress/kendo-angular-buttons';

import { AppComponent } from './app.component';
import { MainHeaderComponent } from './main-header/main-header.component';
import { LoginRegisterComponent } from './login-register/login-register.component';
import { MainAppComponent } from './main-app/main-app.component';
import { ProfileComponent } from './main-app/profile/profile.component';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    MainHeaderComponent,
    LoginRegisterComponent,
    MainAppComponent,
    ProfileComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    DialogModule,
    WindowModule,
    ButtonsModule,
    RouterModule.forRoot([

    ]),
    DialogsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
