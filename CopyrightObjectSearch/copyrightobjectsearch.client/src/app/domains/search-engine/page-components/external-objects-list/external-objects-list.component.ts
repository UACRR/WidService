import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Observable, catchError, map, of, tap, timeout } from 'rxjs';
import { ExternalObjectDto } from '../../server-proxy/dto/external-object-dto';
import { createMap } from '@automapper/core';
import { mapper } from '../../../../mappings/mapper';
import { AutoMap } from '@automapper/classes';
import { DomSanitizer, SafeHtml } from '@angular/platform-browser';
import { slideIn, slideInOut, slideOut } from '../../../../animations';
import { Router } from '@angular/router';
import { SetWorkCodeRsp } from '../../server-proxy/dto/SetWorkCodeRsp';

export class Item {
  id        : number = 0;
  title     : string = '';
  authors   : string = '';
  performers: string = '';
  iswc      : string = '';
  foundObjId: number = 0;
  foundWic  : number = 0;
  foundIswc : string = '';
  foundVia  : string = '';
  createdAt : Date   = new Date();
  updatedAt : Date   = new Date();
};

@Component({
  selector: 'app-external-objects-list',
  templateUrl: './external-objects-list.component.html',
  styleUrls: [
    './external-objects-list.component.css',
    '../../../../app.component.css'
  ],
  animations: [slideInOut]
})
export class ExternalObjectsListComponent implements OnInit {

  items: Item[] = [];

  expandedItem: Item | undefined;
  isEditing = false;

  activeValueEditor = '';

  isAnimationDisabled = false;

  constructor(
    private http: HttpClient,
    private sanitizer: DomSanitizer,
    private router: Router
  ) {
  }

  ngOnInit() {
    this.getItems();
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.log('getItems error returned');
      console.log(error);
      return of(result as T);
    };
  }

  getItems() {
    console.log('getItems entered');
    this.http
      //.get<ExternalObjectDto[]>('http://localhost:5235/api/SearchEngine/GetExternalObjects')
      .get<ExternalObjectDto[]>('http://localhost:7157/api/SearchEngine/GetExternalObjects')
      .pipe(
        tap(_ => console.log('Got')),
        map(res => {
          res.forEach(x => {
            this.items.push({
              id: x.id,
              title: x.title,
              authors: x.authors,
              performers: x.performers,
              iswc: x.iswc,
              foundObjId: x.foundObjId,
              foundWic: x.foundWic,
              foundIswc: x.foundIswc,
              foundVia: x.foundVia,
              createdAt: x.createdAt,
              updatedAt: x.updatedAt,
            });
          });
          this.expandedItem = this.items[0];
          this.isEditing = true;
        }),
        catchError(this.handleError<string>('Forcast', ''))
      )
      .subscribe();
  }

  formatObjId(item: Item): string {
    return item.foundObjId === 0 ? 'Не визначено' :
      item.foundObjId ? item.foundObjId.toString() : 'Не визначено';
  }

  formatWic(item: Item): string {
    return item.foundWic === 0 ? 'Не визначено' :
      item.foundWic ? item.foundWic.toString() : 'Не визначено';
  }

  formatIswc(item: Item): string {
    return item.foundIswc === '' ? 'Не визначено' :
      item.foundIswc ? item.foundIswc.toString() : 'Не визначено';
  }

  isItemExpanded(item: Item): boolean {
    return item == this.expandedItem;
  }

  isEditingItem(item: Item): boolean {
    return item == this.expandedItem && this.isEditing;
  }

  getSearchResultHtml(item: Item, param: string): SafeHtml {
    var icon  = '';
    var color = '';
    switch (param) {
      case 'SMART':
          icon  = item.foundObjId !== 0 ? 'fa-plus-circle' : 'fa-minus-circle';
          color = item.foundObjId !== 0 ? 'forestgreen' : 'palevioletred';
        break;
      case 'WID':
          icon  = item.foundWic !== 0 ? 'fa-plus-circle' : 'fa-minus-circle';
          color = item.foundWic !== 0 ? 'forestgreen' : 'palevioletred';
        break;
      case 'ISWC':
          icon  = item.foundIswc !== '' ? 'fa-plus-circle' : 'fa-minus-circle';
          color = item.foundIswc !== '' ? 'forestgreen' : 'palevioletred';
        break;
    }
    return this.sanitizer.bypassSecurityTrustHtml(
      `<i class="fa ${icon}" style="margin-right: 10px; color: ${color}"> <span style="margin-left: 5px; font-size: small;">${param}</span></i>`
    );
  }

  getCaretClass(item: Item): SafeHtml {
    return this.sanitizer.bypassSecurityTrustStyle(
      this.isItemExpanded(item) ? 'fa fa-chevron-down' : 'fa fa-chevron-right'
    );
  }

  isEditingObjId(item: Item): boolean {
    return this.isItemExpanded(item) && this.isEditing && this.activeValueEditor == 'objid';
  }

  isEditingWic(item: Item): boolean {
    return this.isItemExpanded(item) && this.isEditing && this.activeValueEditor == 'wic';
  }

  isEditingIswc(item: Item): boolean {
    return this.isItemExpanded(item) && this.isEditing && this.activeValueEditor == 'iswc';
  }

  getClassObjIdCell(item: Item): SafeHtml {
    var retVal = this.isEditingObjId(item) ? 'value-span-edited' :
      this.isEditing ? 'value-span-editable' :
        'value-span';
    return this.sanitizer.bypassSecurityTrustStyle(retVal);
  }

  getClassWicCell(item: Item): SafeHtml {
    var retVal = this.isEditingWic(item) ? 'value-span-edited' :
      this.isEditing ? 'value-span-editable' :
        'value-span';
    return this.sanitizer.bypassSecurityTrustStyle(retVal);
  }

  getClassIswcCell(item: Item): SafeHtml {
    var retVal = this.isEditingIswc(item) ? 'value-span-edited' :
      this.isEditing ? 'value-span-editable' :
        'value-span';
    return this.sanitizer.bypassSecurityTrustStyle(retVal);
  }

  getItemHtmlId(itemIdx: number): string {
    return `item-${itemIdx}`;
  }

 onCaretClicked(item: Item) {
    this.isEditing = false;
    this.activeValueEditor = '';
    if (this.isItemExpanded(item)) {
      this.expandedItem = undefined;
    }
    else {
      setTimeout(() => {
        this.expandedItem = item;
      }, 100);
    }
    // for animation
  }

  onEditItemClicked(itemIdx: number) {
    this.editItem(itemIdx);
  }

  onObjIdClicked(item: Item) {
    this.activeValueEditor = 'objid';
  }

  onWicClicked(item: Item) {
    this.activeValueEditor = 'wic';
  }

  onIswcClicked(item: Item) {
    this.activeValueEditor = 'iswc';
  }

  onFinishEditingClicked(item: Item) {
    this.isEditing = false;
    this.expandedItem = undefined;
    this.activeValueEditor = '';
  }

  onEditNextClicked(item: Item, itemIdx: number) {
    if (itemIdx < this.items.length - 1) {
      this.editItem(itemIdx + 1);
    }
  }

  editItem(itemIdx: number) {
    // Animation lasts 200 ms, so need tomout exceeding 200 ms
    const timeout = 220;
    const el = document.getElementById(this.getItemHtmlId(itemIdx));
    if (el) {
      this.isEditing = false;
      this.expandedItem = undefined;
      this.activeValueEditor = '';
      setTimeout(() => {
        const el = document.getElementById(this.getItemHtmlId(itemIdx));
        if (el) {
          const rect = el.getBoundingClientRect();
          window.scrollTo(0, rect.top + window.scrollY);
          setTimeout(() => {
            this.isEditing = true;
            this.expandedItem = this.items[itemIdx];
            this.activeValueEditor = '';
            setTimeout(() => {
              const el = document.getElementById(this.getItemHtmlId(itemIdx));
              if (el) {
                const rect = el.getBoundingClientRect();
                window.scrollTo(0, rect.top + window.scrollY);
              }
            }, timeout);
          }, timeout);
        }
      }, timeout);
    }
  }

  onEditCodeFinished(event: any) {
    if (!event.isCanceled) {
      if (this.expandedItem) {
        this.expandedItem.foundObjId = event.objId;
        this.expandedItem.foundWic = event.wic;
        this.expandedItem.foundIswc = event.iswc;
      }
    }
    this.activeValueEditor = '';
  }

  onEditObjIdFinished(event:any) {
    this.onEditCodeFinished(event);
  }

  onEditWicFinished(event:any) {
    this.onEditCodeFinished(event);
  }

  onEditIswcFinished(event: any) {
    this.onEditCodeFinished(event);
  }

  onObjectSelected(objectCodes: SetWorkCodeRsp) {
    if (this.expandedItem) {
      this.expandedItem.foundObjId = objectCodes.objId;
      this.expandedItem.foundWic = objectCodes.wic;
      this.expandedItem.foundIswc = objectCodes.iswc;
    }
  }

  getInitiaExternalObjectId(): number {
    return this.expandedItem ? this.expandedItem.id : 0;
  }

  getInitiaSearchWorkName(): string {
    return this.expandedItem ? this.expandedItem.title : '';
  }

  getInitialWorkAuthors(): string {
    return this.expandedItem ? '' : '';
  }

  getInitialWorkPerformers(): string {
    return this.expandedItem ? '' : '';
  }
}
