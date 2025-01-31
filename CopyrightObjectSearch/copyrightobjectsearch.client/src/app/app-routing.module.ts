import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TaskManagementComponent } from './domains/task-management/page-components/task-management/task-management.component';
import { UserAdministrationComponent } from './domains/user-administration/page-components/user-administration/user-administration.component';
import { LoginComponent } from './domains/access-control/page-components/login/login.component';
import { PartnerWorksListComponent } from './domains/search-engine/page-components/partner-works-list/partner-works-list.component';

const routes: Routes = [
   { path: '', component: LoginComponent },
   { path: 'domains/search-engine/page-components/external-objects-list'    , component: PartnerWorksListComponent },
   { path: 'domains/search-engine/page-components/partner-works-list'    , component: PartnerWorksListComponent },
   { path: 'domains/task-management/page-components/task-management'        , component: TaskManagementComponent },
   { path: 'domains/user-administration/page-components/user-administration', component: UserAdministrationComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
