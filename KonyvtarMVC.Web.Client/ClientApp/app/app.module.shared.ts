import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { routing } from './app.routing';
import { AuthGuard } from './guards/auth';


import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { BookListComponent } from './components/books/book.list.component';
import { BookDetailsComponent } from './components/books/book.details.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        BookListComponent,
        BookDetailsComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: 'login', component: HomeComponent },

            { path: 'books', component: BookListComponent, canActivate: [AuthGuard] },
            { path: 'books/create', component: BookListComponent, canActivate: [AuthGuard] },
            { path: 'books/:bookId', component: BookDetailsComponent, canActivate: [AuthGuard] },
            { path: 'books/:bookId/edit', component: BookListComponent, canActivate: [AuthGuard] },

            { path: 'books/:bookId/items/create', component: HomeComponent, canActivate: [AuthGuard] },
            { path: 'books/:bookId/items/:itemId/edit', component: HomeComponent, canActivate: [AuthGuard] },
            { path: 'books/:bookId/items/:itemId/delete', component: HomeComponent, canActivate: [AuthGuard] },

            { path: 'users', component: HomeComponent, canActivate: [AuthGuard] },
            { path: 'users/create', component: HomeComponent, canActivate: [AuthGuard] },
            { path: 'users/:userId', component: HomeComponent, canActivate: [AuthGuard] },
            { path: 'users/:userId/edit', component: HomeComponent, canActivate: [AuthGuard] },

            { path: 'rent', component: HomeComponent, canActivate: [AuthGuard] },

            // otherwise redirect to home
            { path: '**', redirectTo: '' }
        ])
    ],
    providers: [
        AuthGuard
    ]
})
export class AppModuleShared {
}
