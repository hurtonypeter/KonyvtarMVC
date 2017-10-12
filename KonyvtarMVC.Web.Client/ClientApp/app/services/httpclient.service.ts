import { Injectable } from '@angular/core';
import { Http, Headers } from '@angular/http';

import { SecurityService } from './security.service';

@Injectable()
export class HttpClient {

    constructor(
        private http: Http,
        private securityService: SecurityService) { }

    appendAuthorizationHeader(headers: Headers) {
        headers.append('Authorization', 'Bearer ' + this.securityService.UserToken);
    }

    get(url: string) {
        let headers = new Headers();
        this.appendAuthorizationHeader(headers);

        return this.http.get(url, {
            headers: headers
        });
    }

    post(url: string, data: any) {
        let headers = new Headers();
        this.appendAuthorizationHeader(headers);

        return this.http.post(url, data, {
            headers: headers
        });
    }

    delete(url: string) {
        let headers = new Headers();
        this.appendAuthorizationHeader(headers);

        return this.http.delete(url, {
            headers: headers
        });
    }
}