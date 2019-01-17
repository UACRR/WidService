import { Subscription } from 'rxjs';


export function unsubscribe(value: Subscription): any {
    if (value != null) {
        value.unsubscribe();
    }
    return null;
}

export const const_id_token = 'id_token';

export function GetBearerToken(): string {
    const token = sessionStorage.getItem(const_id_token);
    // return token ? 'Bearer ' + token : null;
    return token;
}

export const const_id_locale = 'LOCALE_ID';
export function GetLanguage() {
    const sesLang = sessionStorage.getItem(const_id_locale);
    return sesLang ? sesLang : 'en-US';
}
