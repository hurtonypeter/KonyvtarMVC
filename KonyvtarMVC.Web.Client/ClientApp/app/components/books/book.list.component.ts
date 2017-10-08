import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'book-list',
    templateUrl: './book.list.component.html'
})
export class BookListComponent {
    books: any;

    constructor(private http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get(baseUrl + 'api/books').subscribe(res => {
            this.books = res.json();
        }, error => console.error(error));
    }
}