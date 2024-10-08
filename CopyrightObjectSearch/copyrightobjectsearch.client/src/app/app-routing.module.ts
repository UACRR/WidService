import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ExternalObjectsListComponent } from './domains/search-engine/page-components/external-objects-list/external-objects-list.component';
import { InternalObjectsListComponent } from './domains/search-engine/page-components/internal-objects-list/internal-objects-list.component';
import { TaskManagementComponent } from './domains/task-management/page-components/task-management/task-management.component';
import { UserAdministrationComponent } from './domains/user-administration/page-components/user-administration/user-administration.component';
import { LoginComponent } from './domains/access-control/page-components/login/login.component';

const routes: Routes = [
   { path: '', component: LoginComponent },
   { path: 'domains/search-engine/page-components/external-objects-list'    , component: ExternalObjectsListComponent },
   { path: 'domains/search-engine/page-components/internal-objects-list'    , component: InternalObjectsListComponent },
   { path: 'domains/task-management/page-components/task-management'        , component: TaskManagementComponent },
   { path: 'domains/user-administration/page-components/user-administration', component: UserAdministrationComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
