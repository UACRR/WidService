import { Component, OnInit } from '@angular/core';
import { DomSanitizer, SafeHtml } from '@angular/platform-browser';
import { slideInOut } from '../../../../animations';
import { FormControl } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { AddUserRsp } from '../../server-proxy/dto/AddUserRsp';
import { GetUsersRsp } from '../../server-proxy/dto/GetUsersRsp';
import { DeleteUserRsp } from '../../server-proxy/dto/DeleteUsersRsp';
import { DeleteUserRq } from '../../server-proxy/dto/DeleteUsersRq';
import { UpdateUserRq } from '../../server-proxy/dto/UpdateUserRq';
import { UpdateUserRsp } from '../../server-proxy/dto/UpdateUserRsp';

class RoleItem {
  id: number = 0;
  description: string = '';
  isSelected: boolean = false;

  roleChkFormControl: FormControl = new FormControl(false);
}

class UserItem {
  id:    number = 0;
  name:  string = '';
  login: string = '';
  roles: RoleItem[] = [];

  nameFormControl: FormControl = new FormControl('');
  loginFormControl: FormControl = new FormControl('');
}

@Component({
  selector: 'app-user-administration',
  templateUrl: './user-administration.component.html',
  styleUrls: [
    './user-administration.component.css',
    '../../../../app.component.css'
  ],
  animations: [slideInOut]
})
export class UserAdministrationComponent implements OnInit {

  items: UserItem[] = [];
/*    {
      id: 1,
      name: 'Адміністратор користувачів',
      login: 'UserAdmin',
      nameFormControl: new FormControl('Адміністратор користувачів'),
      loginFormControl: new FormControl('UserAdmin'),
      roles: [
        { id: 1, description: 'Адміністратор користувачів', isSelected: true, roleChkFormControl: new FormControl(true) },
        { id: 2, description: 'Адміністратор завдань', isSelected: false, roleChkFormControl: new FormControl(false) },
        { id: 3, description: 'Виконавець завдань', isSelected: false, roleChkFormControl: new FormControl(false)},
      ]
    },
    {
      id: 2,
      name: 'Адміністратор завдань',
      login:  'TaskAdmin',
      nameFormControl: new FormControl('Адміністратор завдань'),
      loginFormControl: new FormControl('TaskAdmin'),
      roles: [
        { id: 1, description: 'Адміністратор користувачів', isSelected: false, roleChkFormControl: new FormControl(false) },
        { id: 2, description: 'Адміністратор завдань', isSelected: true, roleChkFormControl: new FormControl(true) },
        { id: 3, description: 'Виконавець завдань', isSelected: false, roleChkFormControl: new FormControl(false)},
      ]
    },
    {
      id: 3,
      name: 'Виконавець завдань',
      login:  'TaskOperator',
      nameFormControl: new FormControl('Виконавець завдань'),
      loginFormControl: new FormControl('TaskOperator'),
      roles: [
        { id: 1, description: 'Адміністратор користувачів', isSelected: false, roleChkFormControl: new FormControl(false) },
        { id: 2, description: 'Адміністратор завдань', isSelected: false, roleChkFormControl: new FormControl(true) },
        { id: 3, description: 'Виконавець завдань', isSelected: true, roleChkFormControl: new FormControl(false)},
      ]
    },
  ];*/

  expandedItem: UserItem | undefined;

  isConfirmingDelete = false;
  errorText = '';
  infoText = '';

  constructor(
    private http: HttpClient,
    private sanitizer: DomSanitizer,
  ) {

  }

  ngOnInit() {
    this.getUsers();
  }

  getUsers() {
    this.http.get<GetUsersRsp>('http://localhost:5235/api/UserAdministration/GetUsers')
      .subscribe({
        next: response => {
          this.items = [];
          response.users.forEach(x => {
            const isUserAdmin    = x.roleIds.includes(1);
            const isTaskAdmin    = x.roleIds.includes(2);
            const isTaskOperator = x.roleIds.includes(3);
            this.items.push({
              id: x.id,
              name: x.name,
              login: x.login,
              nameFormControl: new FormControl(x.name),
              loginFormControl: new FormControl(x.login),
              roles: [
                { id: 1, description: 'Адміністратор користувачів', isSelected: isUserAdmin     , roleChkFormControl: new FormControl(isUserAdmin)    },
                { id: 2, description: 'Адміністратор завдань'     , isSelected: isTaskAdmin     , roleChkFormControl: new FormControl(isTaskAdmin)    },
                { id: 3, description: 'Виконавець завдань'        , isSelected: isTaskOperator  , roleChkFormControl: new FormControl(isTaskOperator) },
              ]
            });
          });
        },
        error: error => {
        }
      });
  }

  addUser() {
    this.http.get<AddUserRsp>('http://localhost:5235/api/UserAdministration/AddUser')
      .subscribe({
        next: response => {
          const isUserAdmin = response.roleIds.includes(1);
          const isTaskAdmin = response.roleIds.includes(2);
          const isTaskOperator = response.roleIds.includes(3);
          this.items.unshift({
            id: response.id,
            name: response.name,
            login: response.login,
            nameFormControl: new FormControl(response.name),
            loginFormControl: new FormControl(response.login),
            roles: [
              { id: 1, description: 'Адміністратор користувачів', isSelected: isUserAdmin, roleChkFormControl: new FormControl(isUserAdmin) },
              { id: 2, description: 'Адміністратор завдань', isSelected: isTaskAdmin, roleChkFormControl: new FormControl(isTaskAdmin) },
              { id: 3, description: 'Виконавець завдань', isSelected: isTaskOperator, roleChkFormControl: new FormControl(isTaskOperator) },
            ]
          });
          this.expandedItem = this.items[0];
        },
        error: error => {
        }
      });
  }

  updateUser(itemIdx: number) {
    var userItem = this.items[itemIdx];
    const rq: UpdateUserRq = {
      id     : userItem.id,
      name   : userItem.nameFormControl.value,
      login  : userItem.loginFormControl.value,
      roleIds: [],
    };
    userItem.roles.forEach(x => {
      if (x.roleChkFormControl.value) {
        rq.roleIds.push(x.id);
      }
    });
    this.http.post<UpdateUserRsp>('http://localhost:5235/api/UserAdministration/UpdateUser', rq)
      .subscribe({
        next: response => {
          if (response.errorText !== '') {
            this.errorText = response.errorText;
          }
          else {
            userItem.login = userItem.loginFormControl.value;
            userItem.name = userItem.nameFormControl.value;
            userItem.roles.forEach(x => {
              x.isSelected = x.roleChkFormControl.value;
            });

            this.infoText = 'Зміни успішно застосовані';
            setTimeout(() => {
              this.infoText = '';
            }, 2000);
          }
        },
        error: error => {
          this.errorText = error.message;
        }
      });
  }

  deleteUser(itemIdx: number) {
    const rq: DeleteUserRq = {
      userId: this.items[itemIdx].id
    };
    this.http.post<DeleteUserRsp>('http://localhost:5235/api/UserAdministration/DeleteUser', rq)
      .subscribe({
        next: response => {
          this.isConfirmingDelete = false;
          if (response.errorText !== '') {
            this.errorText = response.errorText;
          }
          else {
            this.items.splice(itemIdx, 1);
            this.expandedItem = undefined;
          }
        },
        error: error => {
          this.errorText = error;
        }
      });
  }

  onNewUser() {
    this.addUser();
  }

  onGeneratePassword(itemIdx: number) {
    alert('Не використовується в поточній версії - пароль генерується автоматично за певними правилами на основі облікового запису');
  }

  onUpdateUser(itemIdx: number) {
    this.updateUser(itemIdx);
  }

  onDeleteUser(itemIdx: number) {
    this.isConfirmingDelete = true;
  }

  onDeleteUserConfirmed(itemIdx: number) {
    this.deleteUser(itemIdx);
  }

  onDeleteUserRejected(itemIdx: number) {
    this.isConfirmingDelete = false;
  }

  onErrorClose() {
    this.errorText = '';
  }

  getCaretClass(item: UserItem): SafeHtml {
    return this.sanitizer.bypassSecurityTrustStyle(
      this.isItemExpanded(item) ? 'fa fa-chevron-down' : 'fa fa-chevron-right'
    );
  }

  isItemExpanded(item: UserItem): boolean {
    return item == this.expandedItem;
  }

  resetItemParams(item: UserItem) {
    item.nameFormControl.setValue (item.name);
    item.loginFormControl.setValue(item.login);
    item.roles.forEach(x => {
      x.roleChkFormControl.setValue(x.isSelected);
    });
  }

  onCaretClicked(item: UserItem) {
    this.errorText = '';
    this.isConfirmingDelete = false;
    this.resetItemParams(item);
    if (this.isItemExpanded(item) && this.expandedItem) {
      this.expandedItem = undefined;
    }
    else {
      setTimeout(() => {
        this.expandedItem = item;
      }, 100);
    }
  }

  isActionsDivVisible(item: UserItem): boolean {
    return this.expandedItem == item && !this.isConfirmingDelete && this.errorText === '' && this.infoText === '';
  }

  isConfirmDivVisible(item: UserItem): boolean {
    return this.expandedItem == item && this.isConfirmingDelete && this.errorText === '';
  }

  isErrorDivVisible(item: UserItem): boolean {
    return this.expandedItem == item && this.errorText !== '';
  }

  isInfoDivVisible(item: UserItem): boolean {
    return this.expandedItem == item && this.infoText !== '';
  }

  isUserDataDivVisible(item: UserItem): boolean {
    return this.expandedItem == item;
  }

  isApplyChangesDivVisible(item: UserItem): boolean {
    if (item.name != item.nameFormControl.value) {
      return true;
    }
    if (item.login != item.loginFormControl.value) {
      return true;
    }

    for (var idx = 0; idx < item.roles.length; idx++) {
      const role = item.roles[idx];
      if (role.isSelected != role.roleChkFormControl.value) {
        return true;
      }
    }

    return false;
  }
}
