import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, catchError, connect, map, of, tap } from 'rxjs';
import { AppService } from './app.service';

class MenuItem {
  name: string = '';
  routePath: string = '';
}

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {

  menuItems: MenuItem[] = [
    {name: 'Твори партнерів' , routePath: 'domains/search-engine/page-components/external-objects-list'    },
    {name: 'Твори товариства', routePath: 'domains/search-engine/page-components/internal-objects-list'    },
    {name: 'Завдання'        , routePath: 'domains/task-management/page-components/task-management'        },
    {name: 'Користувачі'     , routePath: 'domains/user-administration/page-components/user-administration'},
  ];

  constructor(
    private appService: AppService,
    private http: HttpClient,
    private router: Router,
  ) {

  }

  ngOnInit() {
  }

  onMenuItemClicked(menuItem: MenuItem) {
    this.router.navigateByUrl(menuItem.routePath);
  }

  isMenuVisible(): boolean {
    return this.appService.userIsMultyRole;
  }

  title = 'УААСП Пошук і Розподіл';
}
