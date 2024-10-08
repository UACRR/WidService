import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthInterceptor } from './auth.interceptor';
import { ExternalObjectsListComponent } from './domains/search-engine/page-components/external-objects-list/external-objects-list.component';
import { InternalObjectsListComponent } from './domains/search-engine/page-components/internal-objects-list/internal-objects-list.component';
import { TaskManagementComponent } from './domains/task-management/page-components/task-management/task-management.component';
import { UserAdministrationComponent } from './domains/user-administration/page-components/user-administration/user-administration.component';
import { CommonModule } from '@angular/common';
import { RouterLink, RouterLinkActive, RouterOutlet, provideRouter } from '@angular/router';
import { ObjIdEditComponent } from './domains/search-engine/helper-components/objid-edit/objid-edit.component';
import { IswcEditComponent } from './domains/search-engine/helper-components/iswc-edit/iswc-edit.component';
import { WicEditComponent } from './domains/search-engine/helper-components/wic-edit/wic-edit.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SearchInSocDbComponent } from './domains/search-engine/helper-components/search-in-soc-db/search-in-soc-db.component';
import { ReactiveFormsModule } from '@angular/forms';
import { CodeEditBaseComponent } from './domains/search-engine/helper-components/code-edit-base/code-edit-base.component';
import { LoginComponent } from './domains/access-control/page-components/login/login.component';

@NgModule({
  declarations: [
    AppComponent,
    ExternalObjectsListComponent,
    InternalObjectsListComponent,
    TaskManagementComponent,
    UserAdministrationComponent,

    CodeEditBaseComponent,
    IswcEditComponent,
    ObjIdEditComponent,
    WicEditComponent,
    SearchInSocDbComponent,

    LoginComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    CommonModule,
    RouterOutlet,
    RouterLink,
    RouterLinkActive,
    BrowserAnimationsModule,
    ReactiveFormsModule,
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
