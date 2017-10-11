import { Component, Inject, OnInit } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

import 'rxjs/add/operator/switchMap';

@Component({
    selector: 'bookitem-edit',
    templateUrl: './bookitem.edit.component.html'
})
export class BookItemEditComponent implements OnInit {
    bookId: any;
    bookItem: any;

    constructor(
        private http: Http,
        @Inject('BASE_URL') private baseUrl: string,
        private route: ActivatedRoute,
        private router: Router) { }

    ngOnInit(): void {
        this.bookId = this.route.snapshot.paramMap.get('bookId');

        let id = this.route.snapshot.paramMap.get('itemId');
        if (id) {
            this.http.get(this.baseUrl + 'api/bookItems/' + id)
                .subscribe(resp => {
                    this.bookItem = resp.json();
                }, err => console.log(err));
        }
        else {
            this.bookItem = {};
        }
    }

    onSubmit(): void {
        let id = this.route.snapshot.paramMap.get('itemId');
        if (id) {
            this.http.put(this.baseUrl + 'api/bookItems/' + id, this.bookItem)
                .subscribe(resp => {
                    this.router.navigate(['/books', this.bookId]);
                }, err => console.log(err));
        }
        else {
            this.bookItem.bookId = this.bookId;
            this.http.post(this.baseUrl + 'api/bookItems', this.bookItem)
                .subscribe(resp => {
                    this.router.navigate(['/books', this.bookId]);
                }, err => console.log(err));
        }
    }
}