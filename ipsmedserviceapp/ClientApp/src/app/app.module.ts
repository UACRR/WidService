import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { MainHeaderComponent } from './main-header/main-header.component';
import { LoginRegisterComponent } from './login-register/login-register.component';
import { MainAppComponent } from './main-app/main-app.component';
import { ProfileComponent } from './main-app/profile/profile.component';


@NgModule({
  declarations: [
    AppComponent,
    MainHeaderComponent,
    LoginRegisterComponent,
    MainAppComponent,
    ProfileComponent,
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
