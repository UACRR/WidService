import { Injectable, Injector } from '@angular/core';
import { ShopingCartService } from '../services/shoping-cart.service';
import { Headers, Response, RequestOptions } from '@angular/http';
import {
  HttpClient,
  HttpEvent,
  HttpInterceptor,
  HttpHandler,
  HttpRequest,
  HttpHeaders
} from '@angular/common/http';
import { Location } from '@angular/common';
import { Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/throw';
import { JwtHelperService } from '@auth0/angular-jwt';
import { LoginModalFormComponent } from '../login-modal-form/login-modal-form.component';


import { GetBearerToken, GetLanguage, const_id_token } from './serviceUtils';


export interface IRegisterData {
  email: string;
  password: string;
  lastname: string;
  name: string;
  phone: string;
  validatePass: string;
}

@Injectable()
export class AuthService {
  public token: string;
  private tokenBody: any = null;
  public redirectUrl = '';
  private loginFormComponent: LoginModalFormComponent;
  public isAdminRequest = false;
  public UniqueName: string;


  ///
  private setupInfo( token ) {
    this.tokenBody = this.jwt.decodeToken(token);
    this.UniqueName = this.tokenBody.unique_name;
    this.isAdminRequest = this.Roles.findIndex( rec => rec === 'AdminRequest') >= 0;

  }

  constructor(
    private _http: HttpClient,
    private _router: Router,
    private _location: Location,
    private jwt: JwtHelperService,
    private shopService: ShopingCartService
  ) {
    if (this.isLoggedIn()) {
      const token = sessionStorage.getItem('id_token');
      this.setupInfo(token);
    }
  }

  get Roles() {
    if (this.isLoggedOut() ) { return []; }
    const roles: string[] = Array.isArray(this.tokenBody.Role)
        ? this.tokenBody.Role
        : [this.tokenBody.Role];

    return roles;
  }

  putSessionData( sd: string ) {
    this.setSession( sd );
  }

  login(userName: string, eMail: string, password: string): Promise<any> {
    const url = this._location.prepareExternalUrl('/api/auth/tokenauth');
    const body = JSON.stringify({ userName, eMail, password });
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json'); // ... Set content type to JSON

    return this._http
      .post<any>(url, body, { headers: headers })
      .toPromise()
      .then(res => {
        this.setSession(res.token);
        if (this.redirectUrl) {
          this._router.navigate([this.redirectUrl]);
        }
      });


  }

  register(regData: IRegisterData ): Promise<any> {
    const url = this._location.prepareExternalUrl('/api/auth/register');

    return this._http.post<any>(url, regData).toPromise();
  }

  confirmEmail(userId: string, token: string): Promise<any> {

    return this._http.put('/api/auth/confirmemail', {userId: userId, token: token}).toPromise();

  }

  resendConfirmationEmail(email: string) {

    const formData = new FormData();
    formData.append('email', email);

    return this._http.put('/api/auth/resendconfirm', formData).toPromise();

  }

  private setSession(authResult) {

    this.setupInfo(authResult);

    const dtExp = new Date(1970, 1, 1);
    dtExp.setTime(dtExp.getTime() + this.tokenBody.exp * 1000);

    sessionStorage.setItem(const_id_token, authResult);
    sessionStorage.setItem('expires_at', JSON.stringify(dtExp.getTime()));

  }

  private clearSessionData() {
    sessionStorage.removeItem(const_id_token);
    this.isAdminRequest = false;
    this.shopService.clearItems();

  }
  logout() {
    this.clearSessionData();
    this._router.navigate(['/catalog']);
  }

  public isLoggedIn() {
    return !this.jwt.isTokenExpired();

  }

  isLoggedOut() {
    return !this.isLoggedIn();
  }

  getExpiration() {
    const expiration = sessionStorage.getItem('expires_at');

    const expiresAt = expiration ? JSON.parse(expiration) : 0;
    const expDate = new Date();
    expDate.setTime(expiresAt);
    return expDate;

  }

  getAuthorizationHeader() {
    return GetBearerToken();
  }

  // ініціалізація зміної форми підключення ( визивається з нав бару )
  setLoginModalForm( form: LoginModalFormComponent ) {
    this.loginFormComponent = form;
  }

  getLoginFormCloseEvent() {
    return this.loginFormComponent.formClosed$;
  }
  openLoginForm() {

    if ( this.loginFormComponent === undefined ) { return; }
    return this.loginFormComponent.open();
  }


}


/**************************************************************** */
@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  constructor() {}

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    // Get the auth header from the service.
    let httpHeader: HttpHeaders = req.headers;
    const lang = GetLanguage();
    httpHeader = httpHeader.set('Accept-Language', lang);

    // const authHeader = GetBearerToken();

    // if (authHeader != null) {
    //   httpHeader = httpHeader.append('Authorization', authHeader);
    // }
    // Clone the request to add the new header.
    const authReq = req.clone({ headers: httpHeader });
    // Pass on the cloned request instead of the original request.
    return next.handle(authReq);
  }
}
