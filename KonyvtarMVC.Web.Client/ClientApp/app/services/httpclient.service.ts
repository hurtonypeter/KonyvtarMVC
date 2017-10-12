import { Injectable } from '@angular/core';
import { Http, Headers } from '@angular/http';

@Injectable()
export class HttpClient {

    constructor(private http: Http) { }

    appendAuthorizationHeader(headers: Headers) {
        headers.append('Authorization', 'Bearer ' + null);
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