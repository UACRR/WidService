import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { DialogModule } from '@progress/kendo-angular-dialog';
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
    BrowserModule,
    DialogModule,
    RouterModule.forRoot([

    ]),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
