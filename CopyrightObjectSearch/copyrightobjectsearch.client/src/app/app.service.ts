import { HttpClient } from "@angular/common/http";
import { EventEmitter, Inject, Injectable } from "@angular/core";
import { NavigationStart, PRIMARY_OUTLET, Router, UrlSegment, UrlSegmentGroup, UrlTree } from "@angular/router";
import { Subject } from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class AppService {
  userId: number = 0;
  constructor() {
  }

}
